using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                testImage.color = new Color( 1, 0, 0 );
                break;
            case 2: //green
                testImage.color = new Color( 0, 1, 0 );
                break;
            case 3: //blue
                testImage.color = new Color( 0, 0, 1 );
                break;
            default:
                break;
        }//end switch
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
