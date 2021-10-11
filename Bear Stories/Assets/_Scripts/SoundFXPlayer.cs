using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXPlayer : MonoBehaviour
{

    public AudioSource audioSource;

    public void PlaySoundEffect( AudioClip aClip )
    {
        audioSource.clip = aClip;
        audioSource.Play();        
    }   
}
