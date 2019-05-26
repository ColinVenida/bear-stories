using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MagicButton : MonoBehaviour
{

    public List<Animation> animList;
    public List<ImageSwaper> swapList;
    public List<AudioClip> audioList;

    private AudioSource source;

    public void MakeMagic()
    {
        //play the stuff here
        Debug.Log( "Magic here" );
    }

    //audio tutorial here
    //https://unity3d.com/learn/tutorials/topics/audio/sound-effects-scripting
    void Start()
    {
        animList = new List<Animation>();
        swapList = new List<ImageSwaper>();
        audioList = new List<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
