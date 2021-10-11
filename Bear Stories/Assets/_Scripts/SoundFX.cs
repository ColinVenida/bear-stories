using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public SoundFXPlayer soundPlayer;
    public AudioClip[] soundClips;

    private int currentSoundIndex = 0;


    public void PlaySoundFX()
    {
        soundPlayer.PlaySoundEffect( soundClips[currentSoundIndex] );
    }

    //TODO ADD functionality to change soundClips through dropdown options and other means


}
