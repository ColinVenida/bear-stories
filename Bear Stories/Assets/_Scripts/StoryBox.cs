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

    public bool haveTextOnSeparateLines;

    private const int SPACE_BETWEEN = 50;
    private const int LINE_HEIGHT = 110;
    private RectTransform storyBoxRT;

    public void Start()
    {
        storyBoxRT = this.GetComponent<RectTransform>();
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
        const int MINIMUM_WIDTH = 300;
        const int CHAR_WIDTH = 40;

        for ( int i = 0; i < dropElementsArray.Length; i++ )
        {
            //resize the dropdown based on the current option's string length       
            int currentValue = dropElementsArray[i].value;
            int optionLength = dropElementsArray[i].options[currentValue].text.Length;            

            if ( optionLength < minimumLength )
            {
                boxWidth = MINIMUM_WIDTH;
            }
            else
            {                
                boxWidth = ( optionLength * CHAR_WIDTH );
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
        if ( haveTextOnSeparateLines )
        {
            ArrangeInSeparateLines();
        }
        else
        {
            ArrangeWithTextWraping();
        }
    }

    private void ArrangeInSeparateLines()
    {
        float yPos = rtArray[0].anchoredPosition.y;
        int numberOfLines = 1;

        for ( int i = 1; i < rtArray.Length; i++ )
        {
            yPos -= LINE_HEIGHT;
            numberOfLines++;
            rtArray[i].anchoredPosition = new Vector3( 0, yPos );
        }

        AdjustStoryBoxPosition( numberOfLines );
        AdjustStoryBoxHeight( numberOfLines );
    }

    private void ArrangeWithTextWraping()
    {
        float nextX = rtArray[0].rect.width + SPACE_BETWEEN;
        float yPos = rtArray[0].anchoredPosition.y;

        int numberOfLines = 1;

        //****NOTE*****
        //research and make notes about anchoredPosition vs localPosition vs rect.position here
        for ( int i = 1; i < rtArray.Length; i++ )
        {
            //if the element won't fit on the current line            
            if ( nextX + rtArray[i].rect.width > storyBoxRT.rect.width )
            {
                yPos -= LINE_HEIGHT;
                numberOfLines++;

                rtArray[i].anchoredPosition = new Vector3( 0, yPos );
                nextX = rtArray[i].rect.width + SPACE_BETWEEN;
            }
            else
            {
                rtArray[i].anchoredPosition = new Vector3( nextX, yPos );
                nextX += rtArray[i].rect.width + SPACE_BETWEEN;
            }
        }//end for

        AdjustStoryBoxPosition( numberOfLines );                
        AdjustStoryBoxHeight( numberOfLines );
    }
    private void AdjustStoryBoxPosition( int linesInBox )    
    {
        const float BOTTOM_OFFSET = 50.0f;
        float adjustedY = (LINE_HEIGHT * linesInBox) + BOTTOM_OFFSET;  
        storyBoxRT.anchoredPosition = new Vector3( storyBoxRT.anchoredPosition.x, adjustedY );  
    }
    private void AdjustStoryBoxHeight( int linesInBox )
    {
        const float BOTTOM_OFFSET = 25.0f;
        float adjustedHeight = (LINE_HEIGHT * linesInBox) + BOTTOM_OFFSET;
        storyBoxRT.sizeDelta = new Vector2( storyBoxRT.sizeDelta.x, adjustedHeight );
    }
}
