using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public SoundFXPlayer soundPlayer;
    public AudioClip[] soundClips;

    private int currentSoundIndex;
    private float playbackPosition;

    private void Start()
    {
        currentSoundIndex = 0;
        playbackPosition = 0.0f;
    }

    public void PlaySoundFX()
    {
        soundPlayer.PlaySoundEffect( soundClips[currentSoundIndex] );
    }

    public void PlaySoundFX_SaveTime()
    {        
        soundPlayer.PlaySound_SaveTime( this );
    }

    public AudioClip GetCurrentSound()
    {
        return soundClips[currentSoundIndex];
    }

    public void SetPlaybackPosition( float time )
    {
        if ( time < 0 || time > soundClips[currentSoundIndex].length )
        {
            Debug.Log( "Invalid playback position, setting to 0.0f" );
            playbackPosition = 0.0f;
        }
        else
        {
            playbackPosition = time;
        }
    }


    public float GetPlaybackPosition()
    {
        return playbackPosition;
    }


    //TODO ADD functionality to change soundClips through dropdown options and other means
}
