using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceManager : MonoBehaviour
{

    public VoiceLines[] voiceLines; //the page's current set of voice lines
    public Toggle voiceToggle;    

    public void PlayPageVO()
    {
        //Debug.Log("PlayPageVO()");
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
