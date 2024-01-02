using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
{
    public StoryBox storyBox;
    public VoiceLines[] objectsWithVoiceLines;
    public AudioSource audioSource;
    public VoiceLinePlayer voiceLinePlayer;
    public SoundFXPlayer soundFXPlayer;
    public Toggle voiceToggle;
    public bool isFirstPage;
    

    private VoiceEnum voiceEnum;
    private List<AudioClip> selectedVoiceLines;
    private List<int> selectedVLIndexes;


    //***TODO*** take all the language selection indexes away from VoiceLines and put them in Page
        //ie. refactor the code so the Page class controls all the voice lines/languages
            //reader changes settings through drop downs, Page remembers the settings, and then Get()'s the correct audio clips
            //from VoiceLines
    public void Awake()
    {        
        selectedVoiceLines = new List<AudioClip>();
        selectedVLIndexes = new List<int>();
    }

    void Start()
    {
        PopulateSelectedVLIndexes();
        PopulateSelectedVoiceLines();
        if( isFirstPage )
        {
            Activate();
        }        
    }    

    private void PopulateSelectedVLIndexes()
    {
        //set them to index 0 for now.  TODO: save the values as PlayerPrefs (do I need to do this???)
        int firstIndex = 0;
        for ( int i = 0; i < objectsWithVoiceLines.Length; i++ )
        {
            selectedVLIndexes.Add( firstIndex );
        }   
    }

    private void PopulateSelectedVoiceLines()
    {       
        try
        {
            for ( int i = 0; i < objectsWithVoiceLines.Length; i++ )
            {
                int index = selectedVLIndexes[i];
                selectedVoiceLines.Add( objectsWithVoiceLines[i].GetCurrentLang()[index] );
            }
        }
        catch ( NullReferenceException e )
        {
            Debug.Log( e.StackTrace );            
            Debug.Log( "Page Null Reference" );            
        }        
    }

    public void Activate()
    {        
        if ( voiceToggle.isOn )
        {
            PlaySelectedVoiceLines();
        }
    }

    public void Deactivate()
    {
        //stop the audio playing. does not work yet; second line still plays after the WaitForSeconds
        audioSource.Stop();
        soundFXPlayer.audioSource.Stop();
        StopCoroutine( VoiceCoroutine() );        
    }

    public void PlaySelectedVoiceLines()
    {
        StartCoroutine( VoiceCoroutine() );
        //StartCoroutine( PlayVoiceClips() );
    }

    IEnumerator VoiceCoroutine()
    {        
        for( int i = 0; i < selectedVoiceLines.Count; i++ )
        {
            audioSource.PlayOneShot( selectedVoiceLines[i] );            
            yield return new WaitForSeconds( selectedVoiceLines[i].length );
        }
    }

    //IEnumerator PlayVoiceClips()
    //{
    //    Debug.Log( "CurrentLanguage = " + GameSettings.CURRENT_LANGUAGE );
    //    AudioClip clip;
    //    for ( int i = 0; i < objectsWithVoiceLines.Length; i++ )
    //    {
    //        clip = objectsWithVoiceLines[i].GetVoiceClip( GameSettings.CURRENT_LANGUAGE, selectedVLIndexes[i] );
    //        audioSource.clip = clip;
    //        audioSource.Play();
    //        yield return new WaitForSeconds( clip.length );
    //    }
    //}

    public void UpdateSelectedVoiceLine( int line, int dropOption )
    {
        try
        {
            selectedVoiceLines[line] = objectsWithVoiceLines[line].GetCurrentLang()[dropOption];
        }
        catch ( IndexOutOfRangeException e )
        {
            Debug.Log( e.StackTrace );            
            Debug.Log( "VOICE LINE NOT SET FOR THIS LANGUAGE AND DROPDOWN OPTION!!!" );            
        }        
    }


    public void UpdateSelectedVLIndex( int index, int value )
    {
        selectedVLIndexes[index] = value;
    }

    public void ChangeVoiceLanguage( int language )
    {
        for( int i = 0; i < objectsWithVoiceLines.Length; i++ )
        {
            objectsWithVoiceLines[i].ChangeVoiceAudio( language );            
        }
        ChangeSelectedLineLanguage();
    }

    private void ChangeSelectedLineLanguage()
    {
        for ( int i = 0; i < selectedVoiceLines.Count; i++ )
        {
            try
            {
                int voiceIndex = selectedVLIndexes[i];
                AudioClip clip = objectsWithVoiceLines[i].GetCurrentLang()[voiceIndex];
                selectedVoiceLines[i] = clip;
            }
            catch ( IndexOutOfRangeException e )
            {
                Debug.Log( e.StackTrace );
                Debug.Log( "VOICE LINE NOT SET FOR THIS LANGUAGE AND DROPDOWN OPTION!!!" );
            }
        }
    }   
}
