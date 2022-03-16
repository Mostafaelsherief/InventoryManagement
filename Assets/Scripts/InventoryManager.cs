using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // those are the slots shown in the Menu
    public List<Item> inventoryElements;
    public Button nextItemsButton;
    public Sprite[] sprites;
    // Contains the Actual savedItems 
    List<Item> savedItems;
    private void Start()
    {
        //To add Listeners if the Save Button was pressed 
        EventHandler.instance.saveItem += AddItem;


        // Menu SLots 
        inventoryElements = new List<Item>();
        for (int i = 0; i < transform.childCount; i++)
        {
            inventoryElements.Add(transform.GetChild(i).GetComponent<Item>());
        }
        LoadSavedItems();

    }


    void LoadSavedItems()
    {
        savedItems = new List<Item>();
        savedItems = SaveData.instance.RetrieveItem();
        Debug.Log(savedItems.Count);
         ShowItems(0); 
    }
    void SetLoadNextItemsButtons(bool toggle)
    {
        nextItemsButton.gameObject.SetActive(toggle);
    }
    bool IsItemAlreadyExists(Item newItem)
    {

        foreach (Item item in savedItems)
        {
            if (item.Color == newItem.Color && item.shapeIndex == newItem.shapeIndex)
            {
                Debug.Log("Item Found ");
                return true;
            }
        }
        return false;
    }
    bool inventoryFilled;
    public void ShowAddedItem(Item newItem)
    {
        inventoryFilled = false;
        int i = 0;
        while (inventoryElements[i].Filled) {
            if (i < inventoryElements.Count - 1)
                i++;
            else 
            {
                inventoryFilled = true;
                break; 
            }
        }
        if (!IsItemAlreadyExists(newItem)&&!inventoryFilled)
        {
            inventoryElements[i].Shape = newItem.Shape;
            inventoryElements[i].shapeIndex = newItem.shapeIndex;
            inventoryElements[i].Color = newItem.Color;
            inventoryElements[i].Filled = true;
            inventoryElements[i].ShowItem();
        }
    }
    void ShowItems(int currentIndex)
    {

        for (int i = 0; i < Mathf.Min((savedItems.Count-currentMenuIndex),inventoryElements.Count); i++) 
        { 
        inventoryElements[i].Shape = savedItems[i + currentMenuIndex].Shape;
        inventoryElements[i].shapeIndex = savedItems[i + currentMenuIndex].shapeIndex;
        inventoryElements[i].Color = savedItems[i + currentMenuIndex].Color;
        inventoryElements[i].Filled = true;
        inventoryElements[i].ShowItem();
        }
    }
    void ClearSlots()
    {
        foreach (Item item in inventoryElements)
        {
            
            item.Shape = null;
            item.shapeIndex = 0;
            item.ClearSlot();
            item.Filled = false;
            item.Color = Color.black;
        }
    }
    void AddItem(Item item)
    {
        savedItems.Add(item);
        ShowAddedItem(item);
        SaveData.instance.SaveItem(item);
    }
   public void LoadNextItems()
    {
        if(currentMenuIndex<savedItems.Count)
        currentMenuIndex += inventoryElements.Count;
        ClearSlots();
        
        ShowItems(currentMenuIndex);
    }
    public void LoadPreviousItems()
    {
        if (currentMenuIndex>0)
            currentMenuIndex -= inventoryElements.Count;
        ClearSlots();
        
            ShowItems(currentMenuIndex);
    }

    int currentMenuIndex = 0;
    










}
