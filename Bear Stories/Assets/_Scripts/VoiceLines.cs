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

    public Dictionary<string, AudioClip[]> voiceLanguages;

    //public because we need to set them in the editor
    public AudioClip[] engVoice;    
    public AudioClip[] espVoice;
    public AudioClip[] deutVoice;
    public AudioSource source;
    public VoiceManager voiceManager;
    
    private int currentClipIndex = 0;       //what clip is accessed (the actual voice line)
    private AudioClip[] currentLanguage;    //what audioclip array is accessed

    public void ChangeAudio( int lang )
    {
        Debug.Log("ChangeAudio(), " + lang);
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

    //function to play the line based on the given int
    public void PlayVO( int dropOptionValue )
    {       
        //Debug.Log( "PlayVO(), line = " + line );        
        //check the line        
        if( dropOptionValue >= currentLanguage.Length )
        {
            Debug.Log("line on current language not set!, " + dropOptionValue );
        }
        else
        {
            currentClipIndex = dropOptionValue;
            StartCoroutine( PlayVoice() );                 
        }       
    }

    IEnumerator PlayVoice()
    {
        if ( voiceManager.IsVoicePlaying() )
        {
            yield return new WaitForSeconds( voiceManager.GetWaitTime() );
        }
        else
        {
            voiceManager.SetPlayingTrue( currentLanguage[currentClipIndex].length );            
        }
        source.PlayOneShot( currentLanguage[currentClipIndex] );
    }

    public AudioClip[] GetCurrentLang()
    {
        return currentLanguage;
    }

    public void PlayVO()
    {
        if( currentLanguage == null )
        {
            Debug.Log( "currentlang == null!" );
            return;
        }
        else
        {
            source.PlayOneShot( currentLanguage[currentClipIndex] );
        }        
    }

    public float GetLineDuration()
    {
        return currentLanguage[currentClipIndex].length;
    }

    public AudioClip GetClip( string language, int index )
    {
        return voiceLanguages[language][index];
    }

    // Start is called before the first frame update
    void Start()
    {
        voiceManager = GetComponentInParent<VoiceManager>();
        voiceLanguages = new Dictionary<string, AudioClip[]>();
        voiceLanguages.Add( "ENGLISH", engVoice );
        voiceLanguages.Add( "ESPANOL", espVoice );
        voiceLanguages.Add( "DEUTCH", deutVoice );
    }

    public void Awake()
    {
        ChangeAudio( 0 );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
