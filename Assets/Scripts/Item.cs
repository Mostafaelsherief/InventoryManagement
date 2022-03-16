using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
    private Sprite image;
    private Color color;
    private Shape shape;
    public Button button;
    // bad Code 
    public int shapeIndex;
    public Image imge;
    private bool filled;
  
 
    public Shape Shape { get => shape; set => shape = value; }
    public Color Color { get => color; set => color = value; }
    public bool Filled { get => filled; set => filled = value; }

  public void ShowItem()
    {

        Debug.Log(shape.image.name);
        Debug.Log(shape.image);
        button.image.sprite = shape.image;
        Debug.Log(color);
        button.image.color = color;
        button.onClick.AddListener(ChooseItem);

    }
    public void ClearSlot()
    {
        shape = null;
        color = Color.black;
        shapeIndex = 0;
        button.image.sprite = null;
        button.image.color = Color.white;
    }
    public void ChooseItem()
    {
        if (shape != null)
        {

            Debug.Log("inside Choose Item");
            Debug.Log(shape.name);
            Debug.Log(color);
            EventHandler.instance.ChooseItem(this);
        }
    }
}
