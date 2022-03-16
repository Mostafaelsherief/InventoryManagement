using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    // Now that's Definitely not well written 
    /*
     
     
     */
    public static SaveData instance;
    private void Awake()
    {
        instance = this;
    }
    public void SaveItem(Item item ) 
    {
        PlayerPrefs.SetInt("itemsCount", PlayerPrefs.GetInt("itemsCount") + 1);
        PlayerPrefs.SetInt("Shape" + PlayerPrefs.GetInt("itemsCount").ToString(), item.shapeIndex);
        PlayerPrefs.SetFloat("ColorR" + PlayerPrefs.GetInt("itemsCount").ToString(), item.Color.r);
        PlayerPrefs.SetFloat("ColorG" + PlayerPrefs.GetInt("itemsCount").ToString(), item.Color.g);
        PlayerPrefs.SetFloat("ColorB" + PlayerPrefs.GetInt("itemsCount").ToString(), item.Color.b);
    }
    public List<Item> RetrieveItem() {
        List <Item> listOfItems = new List<Item>();
        for (int i =1;i < PlayerPrefs.GetInt("itemsCount")+1; i++) 
        {
            Item newITem = new Item();
            newITem.shapeIndex = PlayerPrefs.GetInt("Shape" + i.ToString());
            float r=PlayerPrefs.GetFloat("ColorR" + i.ToString());
            float g=PlayerPrefs.GetFloat("ColorG" + i.ToString());
            float B=PlayerPrefs.GetFloat("ColorB" + i.ToString());
            Color newColor = new Color();
            newColor.r = r;
            newColor.g = g;
            newColor.b = B;
            newColor.a = 1;
            newITem.Color = newColor;
        
            //Bad code 
            newITem.Shape = ObjectsManager.instance.GetShapeinIndex(newITem.shapeIndex);
            Debug.Log(newITem.Shape.name);
            listOfItems.Add(newITem);
        }
        return listOfItems;
    
    }
    
}
