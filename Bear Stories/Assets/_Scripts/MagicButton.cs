using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MagicButton : MonoBehaviour
{
    public Animator animator;  
    public List<ImageSwaper> swapList;  //images in the story to swap out
    public Image stateImage;            //play/pause image
    public Sprite[] stateArray;

    //public List<AudioClip> audioList;
    //public AudioClip clip;

    public AudioSource source;
    private bool animate = false;

    public void MakeMagic()
    {
        //play the stuff here
        animate = !animate;        
        if ( animate )
        {
            source.Play();
            animator.SetBool("PlayAnimation", animate);
            stateImage.sprite = stateArray[1];
        }
        else
        {            
            animator.SetBool("PlayAnimation", animate);
            stateImage.sprite = stateArray[0];
        }        
    }
    
    void Start()
    {        
        swapList = new List<ImageSwaper>();
        //audioList = new List<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
