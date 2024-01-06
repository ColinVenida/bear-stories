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
        else
        {
            //there is no voice line for the given index! throw exception here
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
        return ( index < clips.Length );
    }    
}
