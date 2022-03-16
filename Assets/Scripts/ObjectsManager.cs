using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{

    /* This Script Perfoms a Very simple Object Pooling 
     * Instantiating and Destroying Objects is expensive
     * so We instantiate the objects at the start of the Game
     * and keep them inactive, we activate them when we use
     * them later
     */
    public Shape[] shapesToSpawn;
    List<Shape> spawnedShapes;
    int currentObjectIndex;
    Shape currentShape;
    Color currentColor;
    Item currentItem;

    /*
     I Will create a singelton only used to  Aid the SaveData Class as i had no other way of retrieving the 
    shape Data using only Playerprefs, now all i'll do is just access the shape saved in a specific index for 
    it to appear in the menu ,but other than that it has no usage 
     */
    public static ObjectsManager instance; 
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        instance = this;
        currentItem = new Item();
        EventHandler.instance.changeColor += ChangeColor;
        EventHandler.instance.chooseItem += ChooseItem;
        spawnedShapes = new List<Shape>();
        foreach(Shape shape in shapesToSpawn)
        {
             GameObject obj = Instantiate(shape.gameObject, transform.position + Vector3.up*2, Quaternion.identity);
            spawnedShapes.Add(obj.GetComponent<Shape>());
            obj.SetActive(false);
        }
        spawnedShapes[0].GetComponent<Shape>().ActivateObject();
        currentShape = spawnedShapes[0];
        currentColor = currentShape.Color;

    }
    public void ChooseItem(Item item)
    {
        currentShape.DeactivateObject();
        currentShape = spawnedShapes[item.shapeIndex];
        currentShape.ActivateObject();
        currentShape.GetComponent<Renderer>().material.color = item.Color;
        currentColor = item.Color;
    }
    public void ChangeObject()
    {
        currentObjectIndex++;
        if (currentObjectIndex >= spawnedShapes.Count)
            currentObjectIndex = 0;
        currentShape.DeactivateObject();
        currentShape = spawnedShapes[currentObjectIndex];
        currentShape.ActivateObject();
        currentShape.GetComponent<Renderer>().material.color = currentColor;
    }

    public void ChangeColor(Color color)
    {
        Debug.Log("Change Color ");
        currentShape.GetComponent<Renderer>().material.color = color;
        currentColor = color;
    }
    public void SaveItem()
    {
        Item newItem = new Item();
        newItem.Shape = currentShape;
        newItem.Color = currentColor;
        newItem.shapeIndex = currentObjectIndex;
        EventHandler.instance.SaveItem(newItem);
    }
    
    //badCode
   public Shape GetShapeinIndex(int i )
    {
        return shapesToSpawn[i];
    }
}
