using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{

    public VoiceLines[] voiceLines;

    public void PlayPageVO()
    {
        Debug.Log("PlayPageVO()");
        StartCoroutine( VoiceCoroutine() );
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
