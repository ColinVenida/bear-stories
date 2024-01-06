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
    
    public void PlaySound_SavePreviousTime( SoundFX soundClip )
    {
        //keep playing its the same clip.  IE.  the button was pushed twice
        if ( currentClip == soundClip )
        {
            return;
        }

        //save the last clip's playback spot before playing a new clip
        if( currentClip != null )
        {
            SaveClipTime();
        }

        audioSource.clip = soundClip.GetCurrentSound();         
        audioSource.time = soundClip.GetPlaybackPosition();
        audioSource.Play();
        currentClip = soundClip;
    }

    private void SaveClipTime()
    {
        float time = audioSource.time;
        currentClip.SetPlaybackPosition( time );
    }
}
