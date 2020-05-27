using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using UnityEditorInternal;
using System.Net;

//class that handles the VO lines for each line
public class VoiceLines : MonoBehaviour
{

    //[Serializable]
    //public class VoiceArray
    //{
    //    public AudioClip[] voiceLines;  //array that holds all the variations of the line
    //    public Dropdown voiceDrop;      //reference to the dropdown that controls the line
    //}

    //public VoiceArray[] engVoice;
    //public VoiceArray[] espVoice;
    //public VoiceArray[] deusVoice;

    //public Dropdown[] dropArray;

    public AudioClip[] engVoice;    
    public AudioClip[] espVoice;
    public AudioClip[] deutVoice;
    public AudioSource source;

    private int langSelect;
    private int currentIndex = 0;
    
    private AudioClip[] currentLang;


    //private VoiceArray[] currentLang;

    

    public void ChangeAudio( int lang )
    {
        //Debug.Log("ChangeAudio(), " + lang);
        switch ( lang )
        {
            case 0: //English
                currentLang = engVoice;
                break;
            case 1:
                currentLang = espVoice;
                break;
            case 2:
                currentLang = deutVoice;
                break;
            default:
                Debug.Log( "Default Voice selected.  Setting to English" );
                currentLang = engVoice;
                break;
        }
    }

    //function to play the line based on the given int.  Int should be the value of the Dropdown
    public void PlayVO( int line )
    {       
        Debug.Log( "PlayVO(), line = " + line );
        //check the line        
        if( line > currentLang.Length )
        {
            Debug.Log("line on current language not set!, " + line);
        }
        else
        {
            currentIndex = line;
            source.PlayOneShot(currentLang[currentIndex]);
        }
       
    }

    public void PlayVO()
    {
        source.PlayOneShot(currentLang[currentIndex]);
    }

    public float GetLineDuration()
    {
        return currentLang[currentIndex].length;
    }

    // Start is called before the first frame update
    void Start()
    {
        //source = GetComponent<AudioSource>();
        ChangeAudio( 0 );
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
