using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using System.Net;

//class that handles the VO lines for each line and each language
//add this behavior to Texts or UI-Dropdowns
public class VoiceLines : MonoBehaviour
{
    public int lineIndex;
    public AudioClip[] engVoice;    
    public AudioClip[] espVoice;
    public AudioClip[] deutVoice;
    public Page page;
    public AudioSource audioSource;

    private int selectedLanguage = 0;
    private int currentClipIndex = 0;       //the index for the clip that is accessed (the actual voice line)
    private AudioClip[] currentLanguage;    //the audioclip array that is accessed
        
    public void Start()
    {
        SetLanguageFromPref();
        ChangeVoiceAudio( selectedLanguage );
    }

    private void SetLanguageFromPref()
    {        
        if ( PlayerPrefs.HasKey( "Selected Language" ) )
        {
            selectedLanguage = PlayerPrefs.GetInt( "Selected Language" );            
        }
        else
        {
            PlayerPrefs.SetInt( "Selected Language", selectedLanguage );
        }
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

    //play a voice line for when the reader chooses a different dropdown option
    public void PlayVoiceLine( int option )
    {
        page.UpdateSelectedVoiceLine( lineIndex, option );
        page.UpdateSelectedVLIndex( lineIndex, option );

        if ( !page.voiceToggle.isOn )
        {
            return;
        }
        
        try
        {            
            audioSource.PlayOneShot( currentLanguage[option] );
            
        }
        catch( IndexOutOfRangeException e )
        {
            Debug.Log( e.StackTrace );            
            Debug.Log( "VOICE LINE NOT SET FOR THIS LANGUAGE AND DROPDOWN OPTION!" );            
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

    public AudioClip[] GetLanguage( VoiceEnum vEnum )
    {
        AudioClip[] languageClips;
        switch( vEnum )
        {
            case VoiceEnum.ENGLISH:
                languageClips = engVoice;
                break;
            case VoiceEnum.ESPANOL:
                languageClips = espVoice;
                break;
            case VoiceEnum.DEUTSCH:
                languageClips = deutVoice;
                break;
            default:
                Debug.Log( "Voice not set, defaulting to English" );
                languageClips = engVoice;
                break;
        }
        return languageClips;
    }

    public AudioClip GetVoiceClip( VoiceEnum vEnum, int index )
    {
        AudioClip clip = engVoice[0];
        if ( isVoiceIndexInBounds( vEnum, index ) )
        {
            switch ( vEnum )
            {
                case VoiceEnum.ENGLISH:
                    clip = engVoice[index];
                    break;
                case VoiceEnum.ESPANOL:
                    clip = espVoice[index];
                    break;
                case VoiceEnum.DEUTSCH:
                    clip = deutVoice[index];
                    break;
            }
        }        
        return clip;
    }

    private bool isVoiceIndexInBounds( VoiceEnum vEnum, int index )
    {
        AudioClip[] clips = engVoice;
        switch ( vEnum )
        {
            case VoiceEnum.ENGLISH:
                clips = engVoice;
                break;
            case VoiceEnum.ESPANOL:
                clips = espVoice;
                break;
            case VoiceEnum.DEUTSCH:
                clips = deutVoice;
                break;
        }
        return ( index >= clips.Length );
    }    
}
