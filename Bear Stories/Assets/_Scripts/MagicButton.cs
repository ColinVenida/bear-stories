using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MagicButton : MonoBehaviour
{
    public Animator animator;      
    public Image currentImage;           
    public Sprite[] stateArray;  
    public AudioSource audioSource;
    public AudioClip audioClip;

    private bool shouldAnimate = false;

    public void MakeMagic()
    {
        //play the stuff here
        shouldAnimate = !shouldAnimate;        
        if ( shouldAnimate )
        {
            audioSource.Play();
            animator.SetBool("PlayAnimation", shouldAnimate );
            currentImage.sprite = stateArray[1];
        }
        else
        {            
            animator.SetBool("PlayAnimation", shouldAnimate );
            currentImage.sprite = stateArray[0];
        }        
    } 
}
