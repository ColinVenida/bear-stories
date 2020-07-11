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
    public int textHeight;
    public int dropHeight;

    //reference to the UI dropdowns
    public Dropdown[] dropArray;
     
    private const int SPACE_BETWEEN = 60;
    private const int LINE_HEIGHT = 135;
    private RectTransform rt;

    private void ResizeDropdowns()
    {       
        //resize the dropdbox based on the option with the largest preferredWidth
        for( int i = 0; i < dropArray.Length; i++ ) 
        {            
            
            //resize the dropdown based on the current option's string length
            int width = 0;
            if (dropArray[i].options[dropArray[i].value].text.Length < 5)
            {
                width = 300;
            }
            else
            {
                //width = 100 + ( ( dropArray[i].options[dropArray[i].value].text.Length ) * 50 );                
                width = ( ( dropArray[i].options[dropArray[i].value].text.Length ) * 40 );
            }            
            dropArray[i].GetComponent<RectTransform>().sizeDelta = new Vector2( width, dropHeight );
        }
    }

    private void ResizeText()
    {
        //resize the UI-text elements
        for ( int i = 0; i < textArray.Length; i++ )
        {
            Debug.Log( "preferredWidth = " + textArray[i].preferredWidth );
            textArray[i].rectTransform.sizeDelta = new Vector2( textArray[i].preferredWidth, textHeight );
        }
    }

    public void RepositionElements()
    {        
        float nextX = rtArray[0].rect.width + SPACE_BETWEEN;
        float yPos = rtArray[0].anchoredPosition.y;  
        int lineNumber = -1;
        
        //Debug.Log("nextX Start = " + nextX);

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
            if ( nextX + rtArray[i].rect.width > rt.rect.width )
            {
                lineNumber--;
                  
                yPos -= LINE_HEIGHT;

                //rtArray[i].localPosition = new Vector3( LEFT_MARGIN, yPos + (135 * lineNumber) );
                //rtArray[i].localPosition = new Vector3( LEFT_MARGIN, yPos ) ;
                //rtArray[i].anchoredPosition = new Vector3( LEFT_MARGIN, yPos + (135 * lineNumber) );

                
                rtArray[i].anchoredPosition = new Vector3(0, yPos);                
                nextX = rtArray[i].rect.width + SPACE_BETWEEN;

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
