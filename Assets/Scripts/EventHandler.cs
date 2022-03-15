using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHandler : MonoBehaviour
{
    public static EventHandler instance;
    public event Action<Color> changeColor;
    public event Action<Item> chooseItem;
     public event Action<Item> saveItem;
    private void Awake()
    {
        instance = this;
    }
    public void ChangeColor(Color color)
    {
        changeColor.Invoke(color);
    }
    public void  SaveItem(Item item)
    {
        saveItem.Invoke(item);
    
    }
    public void ChooseItem(Item item)
    {
        chooseItem.Invoke(item);

    }


}
