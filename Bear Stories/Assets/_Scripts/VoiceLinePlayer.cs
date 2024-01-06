using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//probably don't need this class
public class VoiceLinePlayer : MonoBehaviour
{
    private Queue<AudioClip> audioQueue;
    public Queue<AudioClip> AudioQueue { get { return audioQueue; } }

    public AudioSource voiceLineAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioQueue = new Queue<AudioClip>();
    }    

    public void LoadVoiceLines( IEnumerable audioClipCollection )
    {
        foreach( AudioClip clip in audioClipCollection )
        {
            audioQueue.Enqueue( clip );
        }
    }

    public void UnloadVoiceLines()
    {
        audioQueue.Clear();
    }

    public void PlayAllVoiceLines()
    {
        //check if the queue is empty
        while ( audioQueue.Count != 0 )
        {
            voiceLineAudioSource.clip = audioQueue.Dequeue();
            StartCoroutine( PlayVoiceLine() );
        }        
    }

    private IEnumerator PlayVoiceLine()
    {
        voiceLineAudioSource.Play();
        yield return new WaitForSeconds( voiceLineAudioSource.clip.length );
    }    
}
