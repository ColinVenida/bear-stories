﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropResize : MonoBehaviour
{
    private RectTransform rt;
    private Dropdown drop;

    public StoryBox sBox;

    private void Start()
    {
        rt = this.GetComponent<RectTransform>();
        drop = this.GetComponent<Dropdown>();
    }

    //resize the dropdown based on the current option's label length
    public void Resize( int option )
    {
       
        //Debug.Log("options.text = " + (drop.options[option].text));
        //Debug.Log("options.text.Length = " + (drop.options[option].text.Length ) );
        
        int width = 0;
        if (drop.options[option].text.Length < 5 )
        {
            width = 300;
        }
        else
        {
            //width = 100 + ((drop.options[option].text.Length) * 50);  
            width = ( ( drop.options[option].text.Length ) * 40 );
        }
        rt.sizeDelta = new Vector2(width, sBox.dropHeight);
        sBox.RepositionElements();
    }
}
