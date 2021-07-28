using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class PageController : MonoBehaviour
{
    public Page[] PageArray;
    public Button btnNext;
    public Button btnPrev;    
    public Text pageNumber;
    public Dropdown languageDrop;

    public enum LANGUAGE_SETTING
    {
        ENGLISH = 0,
        ESPANOL = 1,
        DEUTCH = 2
    };

    private LANGUAGE_SETTING currentLanguage;
    private int currentPageIndex;    

    // Start is called before the first frame update
    void Start()
    {        
        currentPageIndex = 0;   //TODO properly update currentPageIndex with PlayerPref at the start of the program? (not sure if I really need to do this)
        CheckPageBounds();
        FormatPages();
        SetLanguageFromPref();
    }
   
    private void CheckPageBounds()
    {
        //check whether we are at the beginning or end of the book, then turn off the appropriate next/prev button

        //Debug.Log( "CheckPageBounds() currentPage == " + currentPage );
        //**NOTE** this logic does not work with 2-page books!  Books must have 3 or more pages
        if ( currentPageIndex == 0 )
        {
            btnPrev.gameObject.SetActive( false );
        }
        else if ( currentPageIndex == PageArray.Length - 1 )
        {
            btnNext.gameObject.SetActive( false );
        }
        else
        {
            btnNext.gameObject.SetActive( true );
            btnPrev.gameObject.SetActive( true );
        }

        //update the page number
        pageNumber.text = ( ( currentPageIndex + 1 ).ToString() + "/" + PageArray.Length.ToString() );
    }

    public void FormatPages()
    {
        //format all the pages to the UI elements fit in the box
        for ( int i = 1; i < PageArray.Length; i++ )
        {
            if ( PageArray[i].storyBox.isActiveAndEnabled )
            {
                PageArray[i].storyBox.FormatElements();
            }
        }
    }

    private void SetLanguageFromPref()
    {        
        int language = 0;

        if ( PlayerPrefs.HasKey( "Selected Language" ) )
        {
            language = PlayerPrefs.GetInt( "Selected Language" );            
        }
        else
        {
            PlayerPrefs.SetInt( "Selected Language", language );
        }
        languageDrop.value = language;
    }

    public void ChangeVoiceLanguage( int languageOption )
    {        
        for( int i = 0; i < PageArray.Length; i++ )        
        {            
            PageArray[i].ChangeVoiceLanguage( languageOption );
        }
        PlayerPrefs.SetInt( "Selected Language", languageOption );
    }

    public void NextPage()
    {
        //check array bounds here
        if ( currentPageIndex + 1 < PageArray.Length )
        {            
            TurnPage( currentPageIndex + 1 );
        }
    }

    public void PrevPage()
    {
        if ( currentPageIndex - 1 >= 0 )
        {
            TurnPage( currentPageIndex - 1 );
        }
    }

    private void TurnPage( int page )
    {        
        //move the pages here
        RectTransform currentPageTransform = PageArray[currentPageIndex].GetComponent<RectTransform>();
        RectTransform nextPageTransform = PageArray[page].GetComponent<RectTransform>();

        float currentPageWidth = currentPageTransform.rect.width;
        float nextPageWidth = nextPageTransform.rect.width;

        currentPageTransform.SetInsetAndSizeFromParentEdge( RectTransform.Edge.Right, currentPageWidth, currentPageWidth );
        nextPageTransform.SetInsetAndSizeFromParentEdge( RectTransform.Edge.Left, 0, nextPageWidth );  
                
        PageArray[currentPageIndex].Deactivate();
        PageArray[page].Activate();

        //update the currentPage reference
        currentPageIndex = page;

        CheckPageBounds();
    }

    public int GetCurrentPageIndex()
    {
        return currentPageIndex;
    }   
}
