using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCoverManager : MonoBehaviour
{

    public GameObject[] bookCovers;
    public EnlargedCover cover;

    // Start is called before the first frame update
    void Start()
    {
        int pref = 0;
        if( PlayerPrefs.HasKey( "Selected Language" ) )
        {
            pref = PlayerPrefs.GetInt( "Selected Language" );
        }
        else
        {
            PlayerPrefs.SetInt( "Selected Language", pref );
        }
         
        TranslateCovers( pref );
    }

    public void TranslateCovers( int language )
    {
        for( int i = 0; i < bookCovers.Length; i++ )
        {
            ImageSwaper imageSwaper = bookCovers[i].GetComponentInChildren<ImageSwaper>();
            imageSwaper.SwapImageWithIndex( language );            
        }
        PlayerPrefs.SetInt( "Selected Language", language );
    }
    
}
