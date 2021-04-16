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

    private List<AudioClip> selectedLines;

    public void Awake()
    {
        selectedLines = new List<AudioClip>();        
    }

    void Start()
    {
        PopulateSelectedLines();
        Activate();
    }    

    private void PopulateSelectedLines()
    {
        int firstIndex = 0;        
        try
        {
            for ( int i = 0; i < voiceLineElements.Length; i++ )
            {
                selectedLines.Add( voiceLineElements[i].GetCurrentLang()[firstIndex] );
            }
        }
        catch ( NullReferenceException e )
        {
            Debug.Log( "Page Null Reference" );
            Debug.Log( e.StackTrace );
        }        
    }

    public void Activate()
    {
        if ( voiceToggle.isOn )
        {
            PlaySelectedVoiceLines();
        }
    }

    public void PlaySelectedVoiceLines()
    {
        StartCoroutine( VoiceCoroutine() );
    }

    IEnumerator VoiceCoroutine()
    {        
        for( int i = 0; i < selectedLines.Count; i++ )
        {            
            audioSource.PlayOneShot( selectedLines[i] );
            yield return new WaitForSeconds( selectedLines[i].length );
        }
    }

    public void UpdateSelectedLine( int lineIndex, int dropOption )
    {
        selectedLines[lineIndex] = voiceLineElements[lineIndex].GetCurrentLang()[dropOption];
    }

}
