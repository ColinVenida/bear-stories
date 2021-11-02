using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//behavior that automatically adjusts a dropdown's viewport to show the selected item

public class ScrollSnap : MonoBehaviour
{   
    public Dropdown parentDrop;             
    public RectTransform contentTrans;      
                                            
   
    private void OnEnable()
    {
        //content.position.y controls the location of the viewport and scrollbar 
        //***Alert***
        //OnEnable() is called multiple times when the dropdown is clicked.  I'm guessing the dropdown's template OnEnable() is called, and the
        //OnEnable() of the actual DropdownList object is called

        float contentHeight = contentTrans.rect.height;
        float optionNumber = parentDrop.value + 1;
        float yScale = optionNumber / parentDrop.options.Count;


        //dividing (parentDrop.value + 1) / (total items in the Dropdown) shows us how far down the viewport we need to go
        float y = contentTrans.rect.height * ( parentDrop.value + 1 / parentDrop.options.Count );
        float otherY = contentHeight * yScale;

        //Debug.Log( "y = " + y );
        //Debug.Log( "otherY = " + otherY );
        
        contentTrans.position = new Vector3( contentTrans.position.x, y );        
    }
}
