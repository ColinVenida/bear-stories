using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    public Image testImage;
    //public Image captionImage;

    public void ColorChange( int color )
    {
        switch( color) 
        {
            case 0: // white/default
                testImage.color = new Color( 1, 1, 1 );
                //captionImage.color = new Color(1, 1, 1);
                break;
            case 1: //red
                testImage.color = new Color( 1, 0.5f, 0.5f );
                //captionImage.color = new Color(1, 0.5f, 0.5f);
                break;
            case 2: //green
                testImage.color = new Color( 0.5f, 1, 0.5f );
                //captionImage.color = new Color(0.5f, 1, 0.5f);
                break;
            case 3: //blue
                testImage.color = new Color( 0.5f, 0.5f, 1 );
                //captionImage.color = new Color(0.5f, 0.5f, 1);
                break;
            case 4: //yellow
                testImage.color = new Color( 1, 1, 0.5f );
                //captionImage.color = new Color(1, 1, 0.5f);
                break;
            case 5: //pink
                testImage.color = new Color( 1, 0.6f, 0.8f );
                //captionImage.color = new Color(1, 0.6f, 0.8f);
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
