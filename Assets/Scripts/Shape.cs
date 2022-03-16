using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    private Color color;
    public Sprite image;

    public Sprite Image { get => Image; set => Image = value; }
    public Color Color { get => color; set => color = value; }

    public abstract void ActivateObject();
    public abstract void DeactivateObject();

}
