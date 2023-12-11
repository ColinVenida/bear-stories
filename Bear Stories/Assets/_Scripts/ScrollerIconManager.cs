using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollerIconManager : MonoBehaviour
{
    public ScrollRect scrollRect;
    public Image scrollLeftImage;
    public Image scrollRightImage;

    public void UpdateIcons( Vector2 scrollPosition )
    {           
        if ( scrollPosition.x <= 0.0f )
        {
            scrollLeftImage.gameObject.SetActive( false );
        }
        if ( scrollPosition.x >= 1.0f )
        {
            scrollRightImage.gameObject.SetActive( false );
        }
        if ( scrollPosition.x > 0.0f && scrollPosition.x < 1.0f )
        {
            scrollLeftImage.gameObject.SetActive( true );
            scrollRightImage.gameObject.SetActive( true );
        }
    }        
}
