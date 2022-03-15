using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{

    private void Start()
    {
      
    }
    public void ChangeColor()
    {
        EventHandler.instance.ChangeColor(GetComponent<Image>().color);

        
    }

}
