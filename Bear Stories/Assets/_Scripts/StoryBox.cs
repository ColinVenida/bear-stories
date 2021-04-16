using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBox : MonoBehaviour
{

    //reference to all the RectTransforms for the story's order
    public RectTransform[] rtArray;

    //reference to the UI texts
    public Text[] textElementsArray;
    public int textHeight;
    public int dropHeight;

    //reference to the UI dropdowns
    public Dropdown[] dropElementsArray;
     
    private const int SPACE_BETWEEN = 60;
    private const int LINE_HEIGHT = 135;
    private RectTransform boxRT;

    private void ResizeDropdowns()
    {               
        for( int i = 0; i < dropElementsArray.Length; i++ ) 
        {            
            
            //resize the dropdown based on the current option's string length
            int width = 0;
            if ( dropElementsArray[i].options[dropElementsArray[i].value].text.Length < 5)
            {
                width = 300;
            }
            else
            {
                //width = 100 + ( ( dropArray[i].options[dropArray[i].value].text.Length ) * 50 );                
                width = ( ( dropElementsArray[i].options[dropElementsArray[i].value].text.Length ) * 40 );
            }
            dropElementsArray[i].GetComponent<RectTransform>().sizeDelta = new Vector2( width, dropHeight );
        }
    }

    private void ResizeText()
    {
        //resize the UI-text elements
        for ( int i = 0; i < textElementsArray.Length; i++ )
        {
            Debug.Log( "preferredWidth = " + textElementsArray[i].preferredWidth );
            textElementsArray[i].rectTransform.sizeDelta = new Vector2( textElementsArray[i].preferredWidth, textHeight );
        }
    }

    public void RepositionElements()
    {        
        float nextX = rtArray[0].rect.width + SPACE_BETWEEN;
        float yPos = rtArray[0].anchoredPosition.y;  
        int lineNumber = -1;
        
        //****NOTE*****
        //research and make notes about anchoredPosition vs localPosition vs rect.position here
        for( int i = 1; i < rtArray.Length; i++ )
        {
            //check if the nextX + element.width is greater than the StoryBox.width
            //true
            //  lineNumber--;
            //  nextX = element.width
            //else
            //  Place element next to previous element.  
            //  nextX += element.width + Space
           
            //if the element won't fit on the current line
            if ( nextX + rtArray[i].rect.width > boxRT.rect.width )
            {
                lineNumber--;
                  
                yPos -= LINE_HEIGHT;
                
                rtArray[i].anchoredPosition = new Vector3(0, yPos);                
                nextX = rtArray[i].rect.width + SPACE_BETWEEN;

            }
            else
            {               
                rtArray[i].anchoredPosition = new Vector3( nextX, yPos );
                nextX += rtArray[i].rect.width + SPACE_BETWEEN;                
            }
        }//end for

    }

    public void FormatElements()
    {
        boxRT = this.GetComponent<RectTransform>();
        ResizeDropdowns();
        ResizeText();
        RepositionElements();
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
