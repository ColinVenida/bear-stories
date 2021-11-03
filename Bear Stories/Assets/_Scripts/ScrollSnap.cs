using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//behavior that automatically adjusts a dropdown's viewport to show the selected item
public class ScrollSnap : MonoBehaviour
{   
    public Dropdown parentDrop;             
    public RectTransform contentTrans;
    public RectTransform itemTrans;
   
    private void OnEnable()
    {
        //content.position.y controls the location of the dropdown's viewport and scrollbar. The range of Y is 0 through (the rectangle's height / 2)

        //***Alert***
        //OnEnable() is called multiple times when the dropdown is clicked.  I'm guessing the dropdown's template OnEnable() is called, and the
        //OnEnable() of the actual DropdownList object is called

        float itemHeight = itemTrans.rect.height;        
        float optionIndex = parentDrop.value;     
        float yNext = (itemHeight * optionIndex) / 2;  
        
        contentTrans.position = new Vector3( contentTrans.position.x, yNext );        
    }
}
