using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
//class that handles all the text/voice for each story
public class Book : MonoBehaviour
{
    //the txt files of the story.  Txt files are formatted to be string.Split()
    public TextAsset textEng;
    public TextAsset textEsp;
    public TextAsset textDeus;

    public Text[] storyText;     //array that references all the UI Texts in the book Pages
                                //**NOTE** make sure all the Text elements are in place in the scene!

    public Dropdown[] storyDrops;   //array that refferences all the UI Dropdowns in the book Pages

    private List<string> engText;   //list to hold the final english story.  This is used for translating in between languages
    private List<List<string>> engDrops;

    private List<string> espText;
    private List<List<string>> espDrops;

    private List<string> deusText;
    private List<List<string>> deusDrops;       
    
    private void SplitStory( TextAsset textAss, List<string> langText, List<List<string>> langDrops )
    {        
        string story = textAss.text;
        string[] splitStory = story.Split( new char[] { '\n' } );

        
        for ( int i = 0; i < splitStory.Length; i++ )
        {
            //if the first char is '[', then split it into another list
            if( splitStory[i][0] == '[' )
            {                
                string trimString = splitStory[i].TrimStart( '[' );                
                string trimString2 = trimString.TrimEnd('\n');   
               
                string[] splitOptions = trimString2.Split('|');
                List<string> dropOptions = new List<string>();

                //**bug fix**
                //the last index of the splitOptions always had an extra char for some reason (ie. "snow" would have a length of 5)
                //we are removing the extra char here
                string lastIndex = splitOptions[splitOptions.Length - 1].Remove(splitOptions[splitOptions.Length - 1].Length - 1);  
                splitOptions[splitOptions.Length - 1] = lastIndex;

                foreach ( string s in splitOptions )
                {                    
                    dropOptions.Add( s );
                }                
                langDrops.Add( dropOptions );
            }
            else
            {
                //put in the text List                
                langText.Add( splitStory[i] );
            }
        }//end for       

    }//end SplitStory()

    public void ChangeLanguage( int lang )
    {
        List<string> textList = engText;
        List<List<string>> dropList = engDrops;       

        switch ( lang )
        {
            case 0:     //english
                textList = engText;
                dropList = engDrops;
                break;
            case 1:     //Español (spanish)  
                textList = espText;
                dropList = espDrops;
                break;
            case 2:     //Deutsch  (german)
                textList = deusText;
                dropList = deusDrops;
                break;
            default:
                Debug.Log( "Lang default triggered!" );
                textList = engText;
                dropList = engDrops;
                break;
        }
               
        PopulateUIElements( textList );

        PopulateDropOptions( dropList );        
    }

    private void PopulateUIElements( List<string> textList )
    {
        //Note: if an out of bounds exception is thrown, check the Txt file to see if it's formatted correctly (eg. missing a "|" )
        for ( int i = 0; i < storyText.Length; i++ )
        {
            storyText[i].text = textList[i];
        }
    }

    private void PopulateDropOptions( List<List<string>> dropList )
    {
        //Note: if an out of bounds exception is thrown, check the Txt file to see if it's formatted correctly (eg. missing a "|" )
        for ( int i = 0; i < storyDrops.Length; i++ )
        {
            for ( int j = 0; j < storyDrops[i].options.Count; j++ )
            {
                storyDrops[i].options[j].text = dropList[i][j];

                //update the CaptionText.text
                storyDrops[i].captionText.text = storyDrops[i].options[storyDrops[i].value].text;
            }
        }
    }

    // Start is called before the first frame update    
    void Start()
    {
        engText = new List<string>();
        engDrops = new List<List<string>>();

        espText = new List<string>();
        espDrops = new List<List<string>>();

        deusText = new List<string>();
        deusDrops = new List<List<string>>();
        
        SplitStory( textEng, engText, engDrops );
        SplitStory( textEsp, espText, espDrops );
        SplitStory( textDeus, deusText, deusDrops );

        //set the initial language to english for now
        ChangeLanguage( 0 );
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
