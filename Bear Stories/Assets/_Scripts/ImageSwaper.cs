using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwaper : MonoBehaviour, IObserver<VoiceEnum>
{
    public GameSettings gameSettings;
    public Sprite[] sprites;    
    public Image targetImage;
    public Dropdown dropDown;
    
    void Start()
    {
        gameSettings.Subscribe( this );
    }

    //function called when the GameSettings.CURRENT_LANGUAGE is changed
    public virtual void OnNext( VoiceEnum vEnum )
    {
        int index = ( int )vEnum;
        SwapImageWithIndex( index );
    }

    public void SwapImageWithIndex( int index )
    {
        if ( sprites.Length == 0 )
        {
            return;
        }
        try
        {
              targetImage.sprite = sprites[index];                        
        }
        catch ( IndexOutOfRangeException e )
        {
            Debug.Log( "SwapImageWithIndex(): Index out of Range exception.  Maybe there is no image for the given index" );
            Debug.Log( e.StackTrace );
        }
        catch ( NullReferenceException e )
        {
            Debug.Log( "SwapImageWithIndex(): NullReferenceException." );
            Debug.Log( e.StackTrace );
        }
    }

    public virtual void OnCompleted()
    {

    }

    public virtual void OnError( Exception e )
    {

    }
}
