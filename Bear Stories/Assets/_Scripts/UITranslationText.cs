using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITranslationText : MonoBehaviour
{
    //language order:  English, Espanol, Deutch
    public string[] labels;

    // Start is called before the first frame update
    void Start()
    {
        int pref = 0;
        if ( PlayerPrefs.HasKey( "Selected Language" ) )
        {
            pref = PlayerPrefs.GetInt( "Selected Language" );
        }
        else
        {
            PlayerPrefs.SetInt( "Selected Language", pref );
        }
        
        GetComponentInParent<Text>().text = labels[pref];        
    }
    
    public void TranslateText( int language )
    {
        GetComponentInParent<Text>().text = labels[language];
    }
}
