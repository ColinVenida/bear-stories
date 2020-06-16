using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceManager : MonoBehaviour
{

    public VoiceLines[] voiceLines; //the page's current set of voice lines
    public Toggle voiceToggle;
    public Text timeText;

    private float waitTime;
    private bool voicePlaying = false;

    public void PlayPageVO()
    {
        //Debug.Log("PlayPageVO()");
        if ( !voicePlaying )
        {
            voicePlaying = true;
            waitTime = 0.0f;
            for ( int i = 0; i < voiceLines.Length; i++ )
            {
                waitTime += voiceLines[i].GetLineDuration();
            }
            StartCoroutine( VoiceCoroutine() );
        }        
    }

    IEnumerator VoiceCoroutine()
    {        
        for( int i = 0; i < voiceLines.Length; i++ )
        {
            //play the currently selected VO
            voiceLines[i].PlayVO();             

            //wait for the line to be finished before playing hte next one
            yield return new WaitForSeconds( voiceLines[i].GetLineDuration() ); 
        }         
    }

    public bool IsVoicePlaying()
    {
        return voicePlaying;
    }

    public float GetWaitTime()
    {
        return waitTime;       
    }

    public void SetPlayingTrue( float wait )
    {
        Debug.Log( "SetPlayingTrue()" );
        voicePlaying = true;
        waitTime += wait;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if ( waitTime < 0 )
        {
            voicePlaying = false;
        }
        else
        {
            //timeText.text = waitTime.ToString();
        }
    }
}
