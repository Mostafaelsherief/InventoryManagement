using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // those are the slots shown in the Menu
    public List<Item> inventoryElements;
    public Sprite[] sprites;


    private void Start()
    {
        inventoryElements = new List<Item>();
        EventHandler.instance.saveItem += AddItem;
     
        for(int i=0;i<transform.childCount;i++)
        {
            inventoryElements.Add(transform.GetChild(i).GetComponent<Item>());
        }
        List<Item> newList = new List<Item>();
        newList = SaveData.instance.RetrieveItem();
        Debug.Log(newList.Count);
        foreach(Item item in newList)
        {
            AddItem(item);
        }

    }
    

    public void AddItem(Item newItem)
    {
        int i = 0;
        while (inventoryElements[i].Filled) { i++; }
        inventoryElements[i].Shape= newItem.Shape;
        
        inventoryElements[i].Filled = true;
        inventoryElements[i].ShowItem();
        SaveData.instance.SaveItem(newItem);
    }


}
