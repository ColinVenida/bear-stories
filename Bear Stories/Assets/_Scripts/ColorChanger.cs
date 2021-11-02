using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Example color changer for the TestScene
public class ColorChanger : MonoBehaviour
{
    public Image testImage;
    
    public void ColorChange( int color )
    {
        switch( color) 
        {
            case 0: // white/default
                testImage.color = new Color( 1, 1, 1 );
                break;
            case 1: //red
                testImage.color = new Color( 1, 0.5f, 0.5f );
                break;
            case 2: //green
                testImage.color = new Color( 0.5f, 1, 0.5f );
                break;
            case 3: //blue
                testImage.color = new Color( 0.5f, 0.5f, 1 );
                break;
            case 4: //yellow
                testImage.color = new Color( 1, 1, 0.5f );
                break;
            case 5: //pink
                testImage.color = new Color( 1, 0.6f, 0.8f );
                break;
            default:
                break;
        }
    }    
}
