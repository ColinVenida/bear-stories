﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//this class is coded only for demo purposes
//proper class design for the story text needs to be implemented

public class Translator : MonoBehaviour
{
    public Dropdown langDrop;
    public Dropdown colorDrop;
    public Dropdown partDrop;
    public Text story1;
    public Text story2;

    private string[] engColors = { "Gray Elephant", "Red Elephant", "Green Elephant", "Blue Elephant", "Yellow Elephant", "Pink Elephant" };
    private string[] espColors = { "Elefante Gris", "Elefante Rojo", "Elefante Verde", "Elefante Azul", "Elefante Amarillo", "Elefante Rosa" };
    private string[] deuColors = { "Graue Elefant", "Roter Elefant", "Grüner Elefant", "Blaue Elefant", "Gelbe Elefant", "Rosa Elefant" };

    private string[] engPart = { "sun", "rain", "snow" };
    private string[] espPart = { "al sol", "en la lluvia", "en la nieve" };
    private string[] deuPart = { "in der Sonne", "im Regen", "im Schnee" };

    public void ChangeLanguage( int lang )
    {
        TranslateColors( lang );
        TranslateParticles( lang );
        switch ( lang )
        {
            case 0:  //English
                story1.text = "Harold, the";
                story2.text = "sat in the";
                break;

            case 1:  //Español (spanish)  
                story1.text = "Harold, el";
                story2.text = "se sentó";                
                break;

            case 2:  //Deutsch  (german)
                story1.text = "Harold, der";
                story2.text = "saß";                
                break;

            default:
                break;
        }
    }

    private void TranslateColors( int lang )
    {
        string[] language;
        switch( lang )
        {
            case 0:
                language = engColors;
                break;
            case 1:
                language = espColors;
                break;
            case 2:
                language = deuColors;
                break;
            default:
                Debug.Log( "default TranslateColors triggered" );
                language = engColors;
                break;
        }

        for ( int i = 0; i < colorDrop.options.Capacity; i++ )
        {
            colorDrop.options[i].text = language[i];
        }

        //update dropdown's captionText
        colorDrop.captionText.text = colorDrop.options[colorDrop.value].text;

    }

    private void TranslateParticles( int lang )
    {
        string[] language;
        switch (lang)
        {
            case 0:
                language = engPart;
                break;
            case 1:
                language = espPart;
                break;
            case 2:
                language = deuPart;
                break;
            default:
                Debug.Log( "default TranslateColors triggered" );
                language = engPart;
                break;
        }
        for (int i = 0; i < partDrop.options.Capacity; i++)
        {
            partDrop.options[i].text = language[i];
        }
        //update dropdown's captionText
        partDrop.captionText.text = partDrop.options[partDrop.value].text;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log( "===ColorDrop options===" );
        //Debug.Log( colorDrop.options[0].text );
        Debug.Log( colorDrop.options.Capacity );
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
