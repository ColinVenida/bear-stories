#if UNITY_EDITOR
using Codice.CM.Common;
#endif
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UITranslator : MonoBehaviour, IObserver<VoiceEnum>
{
    public GameSettings gameSettings;
    public UITranslationText[] uiTexts;

    void Start()
    {
        gameSettings.Subscribe( this );
    }

    //function called when the GameSettings.CURRENT_LANGUAGE is changed
    public virtual void OnNext( VoiceEnum vEnum )
    {
        int language = ( int )vEnum;
        for ( int i = 0; i < uiTexts.Length; i++ )
        {
            uiTexts[i].TranslateText( language );
        }
    }

    public virtual void OnCompleted()
    {
        //no implementation
    }

    public virtual void OnError( Exception e )
    {
        //no implementation
    }
}
