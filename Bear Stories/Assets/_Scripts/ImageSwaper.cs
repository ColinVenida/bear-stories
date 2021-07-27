using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwaper : MonoBehaviour
{
    public Sprite[] sprites;    
    public Image swapImage;
    public Dropdown dropDown;
    
    public void SwapImageWithDropdown( int dropValue )
    {
        if( dropValue < sprites.Length )
        {
            swapImage.sprite = sprites[dropValue];
        }
        else
        {
            Debug.Log( "***no associated sprite for the dropdown option: " + dropValue );
        }
        
    }
}
