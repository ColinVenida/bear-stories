using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//class that handles all the text/voice for each story
public class Book : MonoBehaviour
{

    //public page array[]
    // public/private translator
    //story textEng
    public TextAsset textEng;
    //story textEsp
    //story textDeus

    //private ArrayList storyEng; //data structure that holds the story elements
    public Text[] storyText;     //array that references all the UI Texts in the book Pages
                                //**NOTE** make sure all the Text elements are in place in the scene!

    public Dropdown[] storyDrops;


    //private ArrayList engText;   //array to hold the final english story.  This is used for translating in between languages
    private List<string> engText;   //array to hold the final english story.  This is used for translating in between languages

    private List<List<string>> engDrops;

    //string[] storyEng
    //string[] storyEsp
    //string[] storyDeus

    //sound[] voiceEng
    //sound[] voiceEsp
    //sound[] voiceDeus

    private void SplitStory()
    {       
        string story = textEng.text;        
        string[] splitStory = story.Split( new char[] { '\n' } );

        //foreach ( string s in splitStory )
        for ( int i = 0; i < splitStory.Length; i++ )
        {
            //if the first char is '[', then skip that string
            if( splitStory[i][0] == '[' )
            {
                //TODO split again and put it in the dropdown array
                //Debug.Log( "dropArray[0].options[0].text = " + dropArray[0].options[0].text );
                string trimString = splitStory[i].TrimStart( '[' );

                string[] splitOptions = trimString.Split( '|' );
                List<string> dropOptions = new List<string>();

                foreach( string s in splitOptions )
                {                    
                    dropOptions.Add( s );
                }
                engDrops.Add( dropOptions );                 
            }
            else
            {
                //put in the text List                
                engText.Add( splitStory[i] );
            }
        }//end for

        //populate the text UI elements
        for ( int i = 0; i < storyText.Length; i++ )
        {
            storyText[i].text = engText[i];
        }

        //populate the dropdown options
        for( int i = 0; i < storyDrops.Length; i++ )
        {            
            for( int j = 0; j < storyDrops[i].options.Count; j++ )
            {
                storyDrops[i].options[j].text = engDrops[i][j];
            } 
        }       

    }//end SplitStory()

    // Start is called before the first frame update    
    void Start()
    {        
        engText = new List<string>();
        engDrops = new List<List<string>>();
        SplitStory();        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
