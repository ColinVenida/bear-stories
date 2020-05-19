using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBox : MonoBehaviour
{

    //reference to all the RectTransforms for the story's order
    public RectTransform[] rtArray;

    //reference to the UI texts
    public Text[] textArray;

    //reference to the UI dropdowns
    public Dropdown[] dropArray;
    
    private const int LEFT_MARGIN = 90;
    private const int SPACE_BETWEEN = 60;
    private const int LINE_HEIGHT = 135;
    private RectTransform rt;

    private void ResizeElements()
    {
        
        //an objects perferredWidth is what the width the object WANTS to be
        //resize the UI-text elements
        for (int i = 0; i < textArray.Length; i++)
        {            
            textArray[i].rectTransform.sizeDelta = new Vector2( textArray[i].preferredWidth, 125 );            
        }     

        //resize the dropdbox based on the option with the largest preferredWidth
        for( int i = 0; i < dropArray.Length; i++ ) 
        {            
            int largestIndex = 0;
            int oldValue = dropArray[i].value;

            //the VERY not-elegant solution
            //find the option with the largest string length
            //set the dropdown value to that option, then use the Dropdown's preferred width to resize the dropdown
            //then change the dropdown.value back to its original value
            for ( int j = 0; j < dropArray[i].options.Count; j++ )
            {       
               if( dropArray[i].options[j].text.Length > dropArray[i].options[largestIndex].text.Length )
               {                    
                    largestIndex = j;
               }
            }

            //for (int j = 0; j < dropArray[i].options.Count; j++)
            //{
            //    dropArray[i].captionText.
            //}

            dropArray[i].value = largestIndex;
            dropArray[i].GetComponent<RectTransform>().sizeDelta = new Vector2( dropArray[i].captionText.preferredWidth + 150, 125 );
            dropArray[i].value = oldValue;            
        }
    }

    private void RepositionElements()
    {                
        float nextX = LEFT_MARGIN + rtArray[0].rect.width + SPACE_BETWEEN;        
        float yPos = rtArray[0].anchoredPosition.y;  
        int lineNumber = -1;


        //****NOTE*****
        //research and make notes about anchoredPosition vs localPosition vs rect.position here

        for( int i = 1; i < rtArray.Length; i++ )
        {
            //check if the nextX + element.width is greater than the StoryBox.width
            //true
            //  lineNumber--;
            //  start new line at LEFT_MARGIN.  
            //  nextX = LEFT_MARGIN + element.width
            //else
            //  Place element next to previous element.  
            //  nextX += element.width + Space
           
            //if the element won't fit on the current line
            if ( nextX + rtArray[i].rect.width > rt.rect.width )
            {
                lineNumber--;
                //Debug.Log( " i, lineNumber = " + i + ", " + lineNumber );      
                
                yPos -= LINE_HEIGHT;               
                
                //rtArray[i].localPosition = new Vector3( LEFT_MARGIN, yPos + (135 * lineNumber) );
                //rtArray[i].localPosition = new Vector3( LEFT_MARGIN, yPos ) ;
                //rtArray[i].anchoredPosition = new Vector3( LEFT_MARGIN, yPos + (135 * lineNumber) );

                rtArray[i].anchoredPosition = new Vector3( LEFT_MARGIN, yPos );
                nextX = LEFT_MARGIN + rtArray[i].rect.width + SPACE_BETWEEN;                
            }
            else
            {               
                //rtArray[i].localPosition = new Vector3( nextX, yPos );
                //rtArray[i].transform.localPosition= new Vector3( nextX, yPos );
                rtArray[i].anchoredPosition = new Vector3( nextX, yPos );
                nextX += rtArray[i].rect.width + SPACE_BETWEEN;                
            }
        }//end for

    }

    public void FormatElements()
    {
        rt = this.GetComponent<RectTransform>();
        ResizeElements();
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
