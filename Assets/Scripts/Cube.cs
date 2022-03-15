using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cube: Shape
{
    
    private Color color;

    public override void ActivateObject()
    {
        gameObject.SetActive(true);
        LeanTween.rotateAround(gameObject, Vector3.up, 180, 1).setEaseInBack().setLoopPingPong();
    }

    public override void DeactivateObject()
    {
        gameObject.SetActive(false) ;
    }
}
