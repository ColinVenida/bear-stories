using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MagicButton : MonoBehaviour
{
    public Animator animator;  
    public List<ImageSwaper> swapList;
    public List<AudioClip> audioList;

    private AudioSource source;
    private bool animate = false;

    public void MakeMagic()
    {
        //play the stuff here        

        animate = !animate;
        //Debug.Log( "animate = " + animate );
        if ( animate )
        {
            //Debug.Log("Magic Start");
            animator.SetBool("PlayAnimation", animate);           
        }
        else
        {
            //Debug.Log("Magic Stop");
            animator.SetBool("PlayAnimation", animate);
        }
    }
    
    //audio tutorial here
    //https://unity3d.com/learn/tutorials/topics/audio/sound-effects-scripting
    void Start()
    {        
        swapList = new List<ImageSwaper>();
        audioList = new List<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
