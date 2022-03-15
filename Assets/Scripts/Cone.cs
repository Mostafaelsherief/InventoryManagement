using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : Shape
{
    public override void ActivateObject()
    {
        gameObject.SetActive(true);
        LeanTween.moveY(gameObject, 4, 1).setEaseInBack().setLoopPingPong();
    }

    public override void DeactivateObject()
    {
        gameObject.SetActive(false);
    }
}
