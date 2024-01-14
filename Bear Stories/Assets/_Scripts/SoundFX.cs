using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{    
    public AudioClip[] soundClips;

    private int currentSoundIndex;  //no functions modify this value yet
    private float playbackPosition;

    private void Start()
    {
        currentSoundIndex = 0;
        playbackPosition = 0.0f;
    }

    public AudioClip GetCurrentSound()
    {
        return soundClips[currentSoundIndex];
    }

    public AudioClip GetSoundFX( int index )
    {
        return soundClips[index];
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
}
