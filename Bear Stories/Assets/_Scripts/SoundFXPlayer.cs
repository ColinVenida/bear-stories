using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXPlayer : MonoBehaviour
{

    public AudioSource audioSource;

    private SoundFX currentClip;

    public void PlaySoundEffect( AudioClip aClip )
    {
        audioSource.clip = aClip;
        audioSource.Play();           
    }
    
    public void PlaySound_SaveTime( SoundFX soundClip )
    {
        if( currentClip != null )
        {
            float time = audioSource.time;
            currentClip.SetPlaybackPosition( time );
        }

        audioSource.clip = soundClip.GetCurrentSound();         
        audioSource.time = soundClip.GetPlaybackPosition();
        audioSource.Play();
        currentClip = soundClip;
    }
}
