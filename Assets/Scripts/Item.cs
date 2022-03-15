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

       


    }
    public void ChooseItem()
    {
        EventHandler.instance.ChooseItem(this);

    }
}
