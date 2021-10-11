using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
{
    public StoryBox storyBox;
    public VoiceLines[] voiceLineElements;
    public AudioSource audioSource;
    public Toggle voiceToggle;
    public bool isFirstPage;
    
    private List<AudioClip> selectedVoiceLines;
    private List<int> selectedVLIndexes;

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
        for ( int i = 0; i < voiceLineElements.Length; i++ )
        {
            selectedVLIndexes.Add( firstIndex );
        }   
    }

    private void PopulateSelectedVoiceLines()
    {       
        try
        {
            for ( int i = 0; i < voiceLineElements.Length; i++ )
            {
                int index = selectedVLIndexes[i];
                selectedVoiceLines.Add( voiceLineElements[i].GetCurrentLang()[index] );
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
        StopCoroutine( VoiceCoroutine() );
        
    }

    public void PlaySelectedVoiceLines()
    {
        StartCoroutine( VoiceCoroutine() );
    }

    IEnumerator VoiceCoroutine()
    {        
        for( int i = 0; i < selectedVoiceLines.Count; i++ )
        {
            audioSource.PlayOneShot( selectedVoiceLines[i] );            
            yield return new WaitForSeconds( selectedVoiceLines[i].length );
        }
    }
        
    public void UpdateSelectedVoiceLine( int line, int dropOption )
    {
        try
        {
            selectedVoiceLines[line] = voiceLineElements[line].GetCurrentLang()[dropOption];
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
        for( int i = 0; i < voiceLineElements.Length; i++ )
        {
            voiceLineElements[i].ChangeVoiceAudio( language );            
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
                AudioClip clip = voiceLineElements[i].GetCurrentLang()[voiceIndex];
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
