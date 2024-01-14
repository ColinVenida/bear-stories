using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
{
    public StoryBox storyBox;
    public VoiceLines[] objectsWithVoiceLines;
    public Dropdown[] storyDropdowns;
    public Button[] buttonsWithSoundFX;
    public AudioSource audioSource;    
    public SoundFXPlayer soundFXPlayer;
    public Toggle voiceToggle;
    public bool isFirstPage;    
            
    private List<int> selectedVLDropOptions;
    private List<int> selectedSoundFXDropOptions;
    
    public void Awake()
    {        
        selectedVLDropOptions = new List<int>(); //index is which dropdown is being referenced in the scene, the value is which option is selected
        selectedSoundFXDropOptions = new List<int>();
    }

    void Start()
    {        
        PopulateSelectedVLDropdownOptions();
        AddVoiceListenersToDropdowns();
        AddListenersToSoundFXButtons();
        if ( isFirstPage )
        {            
            Activate();
        }
    }    

    private void PopulateSelectedVLDropdownOptions()
    {
        int firstIndex = 0;
        for ( int i = 0; i < objectsWithVoiceLines.Length; i++ )
        {
            selectedVLDropOptions.Add( firstIndex );
        }
    }    

    private void AddVoiceListenersToDropdowns()
    {
        foreach ( Dropdown drop in storyDropdowns )
        {
            drop.onValueChanged.AddListener( delegate { PlayVoiceFromDropdown( drop ); } );
            drop.onValueChanged.AddListener( delegate { UpdateSelectedDropdownOptions( drop ); } );
        }
    }

    private void PlayVoiceFromDropdown( Dropdown drop )
    {
        VoiceLines vLine = (VoiceLines) drop.GetComponent( "VoiceLines" );
        PlaySingleVoiceLine( vLine.lineIndex, drop.value );
    }

    private void PlaySingleVoiceLine( int lineIndex, int dropValue )
    {
        AudioClip clip = objectsWithVoiceLines[lineIndex].GetVoiceClip( GameSettings.current_language, dropValue );
        audioSource.clip = clip;
        audioSource.Play();
    }

    private void UpdateSelectedDropdownOptions( Dropdown drop )
    {
        VoiceLines vLine = ( VoiceLines )drop.GetComponent( "VoiceLines" );
        selectedVLDropOptions[vLine.lineIndex] = drop.value;
    }

    private void AddListenersToSoundFXButtons()
    {
        foreach( Button sndButton in buttonsWithSoundFX )
        {
            SoundFX soundFX = ( SoundFX )sndButton.GetComponent<SoundFX>();
            sndButton.onClick.AddListener( delegate { PlaySoundFX( soundFX ); } );
        }
    }

    private void PlaySoundFX( SoundFX soundFX )
    {
        //Debug.Log( "Playing Sound!" );        
        soundFXPlayer.PlaySound_SavePreviousTime( soundFX );
    }

    public void Activate()
    {        
        if ( voiceToggle.isOn )
        {
            PlaySelectedVoiceLines( );
        }
    }

    public void Deactivate()
    {        
        audioSource.Stop();
        soundFXPlayer.audioSource.Stop();        
    }
        
    public void PlaySelectedVoiceLines()
    {        
        StartCoroutine( PlayAllVoiceClips() );
    }

    IEnumerator PlayAllVoiceClips()
    {        
        AudioClip clip;
        for ( int i = 0; i < objectsWithVoiceLines.Length; i++ )
        {            
            clip = objectsWithVoiceLines[i].GetVoiceClip( GameSettings.current_language, selectedVLDropOptions[i] );
            audioSource.clip = clip;
            audioSource.Play();
            yield return new WaitForSeconds( clip.length );
        }
    }
}
