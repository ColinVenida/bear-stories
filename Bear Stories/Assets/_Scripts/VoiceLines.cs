using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using UnityEditorInternal;
using System.Net;

//class that handles the VO lines for each line and each language
public class VoiceLines : MonoBehaviour
{
    public int lineIndex;
    public AudioClip[] engVoice;    
    public AudioClip[] espVoice;
    public AudioClip[] deutVoice;
    public Page page;
    public AudioSource audioSource;
    
    private int currentClipIndex = 0;       //the clip that is accessed (the actual voice line)
    private AudioClip[] currentLanguage;    //the audioclip array that is accessed
        
    public void Start()
    {
        ChangeVoiceAudio( 0 );
    }

    public void ChangeVoiceAudio( int lang )
    {        
        switch ( lang )
        {
            case 0: //English
                currentLanguage = engVoice;
                break;
            case 1:
                currentLanguage = espVoice;
                break;
            case 2:
                currentLanguage = deutVoice;
                break;
            default:
                Debug.Log( "Default Voice selected.  Setting to English" );
                currentLanguage = engVoice;
                break;
        }
    }

    public void PlayVoiceLine( int option )
    {        
        page.UpdateSelectedVoiceLine( lineIndex, option );
        page.UpdateSelectedVLIndex( lineIndex, option );
        try
        {
            audioSource.PlayOneShot( currentLanguage[option] );
        }
        catch( IndexOutOfRangeException e )
        {
            Debug.Log( "===PlayVoiceLine()===" );
            Debug.Log( "VOICE LINE NOT SET FOR THIS LANGUAGE AND DROPDOWN OPTION!" );
            Debug.Log( e.StackTrace );
        }        
    }    

    public AudioClip[] GetCurrentLang()
    {
        return currentLanguage;
    }

    public float GetLineDuration()
    {
        return currentLanguage[currentClipIndex].length;
    }    
}
