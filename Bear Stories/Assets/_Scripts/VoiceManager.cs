using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceManager : MonoBehaviour
{

    public VoiceLines[] voiceLineElements; 
    public Toggle voiceToggle;
    public Text timeText;
    public AudioSource source;

    private string currentLanguage;
    private float waitTime;
    private bool voicePlaying = false;

    public void PlayPageVO()
    {
        //Debug.Log("PlayPageVO()");
        if ( !voicePlaying )
        {
            voicePlaying = true;
            waitTime = 0.0f;
            for ( int i = 0; i < voiceLineElements.Length; i++ )
            {
                waitTime += voiceLineElements[i].GetLineDuration();
            }
            StartCoroutine( VoiceCoroutine() );
        }        
    }

    IEnumerator VoiceCoroutine()
    {        
        for( int i = 0; i < voiceLineElements.Length; i++ )
        {
            //play the currently selected VO
            voiceLineElements[i].PlayVO();             

            //wait for the line to be finished before playing hte next one
            yield return new WaitForSeconds( voiceLineElements[i].GetLineDuration() ); 
        }         
    }

    public void ChangeLanguage( int value )
    {
        switch( value )
        {
            case 0:
                currentLanguage = "ENGLISH";
                break;
            case 1:
                currentLanguage = "ESPANOL";
                break;
            case 2:
                currentLanguage = "DEUTCH";
                break;
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

    public void SetPlayingTrue( float lineDuration )
    {
        Debug.Log( "SetPlayingTrue()" );
        voicePlaying = true;
        waitTime += lineDuration;
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
