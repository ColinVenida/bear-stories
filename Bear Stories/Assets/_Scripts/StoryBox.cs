using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBox : MonoBehaviour
{
    public RectTransform[] rtArray;     //reference to all the RectTransforms for the story's order
    public Text[] textElementsArray;    //reference to the UI texts    
    public Dropdown[] dropElementsArray;    //reference to the UI dropdowns

    public int textHeight;
    public int dropHeight;
     
    private const int SPACE_BETWEEN = 60;
    private const int LINE_HEIGHT = 135;
    private RectTransform boxRT;

    public void Start()
    {
        boxRT = this.GetComponent<RectTransform>();
    }

    public void FormatElements()
    {        
        ResizeDropdowns();
        ResizeText();
        RepositionElements();
    }

    private void ResizeDropdowns()
    {
        int minimumLength = 5;
        int boxWidth;

        for( int i = 0; i < dropElementsArray.Length; i++ ) 
        {
            //resize the dropdown based on the current option's string length       
            int currentValue = dropElementsArray[i].value;
            int optionLength = dropElementsArray[i].options[currentValue].text.Length;            

            if ( optionLength < minimumLength )
            {
                boxWidth = 300;
            }
            else
            {
                //width = 100 + ( ( dropArray[i].options[dropArray[i].value].text.Length ) * 50 );                
                boxWidth = ( ( optionLength ) * 40 );
            }
            dropElementsArray[i].GetComponent<RectTransform>().sizeDelta = new Vector2( boxWidth, dropHeight );
        }
    }

    private void ResizeText()
    {
        //resize the UI-text elements
        for ( int i = 0; i < textElementsArray.Length; i++ )
        {
            float pWidth = textElementsArray[i].preferredWidth;                         
            textElementsArray[i].rectTransform.sizeDelta = new Vector2( pWidth, textHeight ); 
        }
    }

    public void RepositionElements()
    {        
        float nextX = rtArray[0].rect.width + SPACE_BETWEEN;
        float yPos = rtArray[0].anchoredPosition.y;          
        
        //****NOTE*****
        //research and make notes about anchoredPosition vs localPosition vs rect.position here
        for( int i = 1; i < rtArray.Length; i++ )
        {
            //if the element won't fit on the current line            
            if ( nextX + rtArray[i].rect.width > boxRT.rect.width )
            {                  
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
}
