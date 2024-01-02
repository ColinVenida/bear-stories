using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Codice.CM.Client.Differences;

public class PageController : MonoBehaviour, IObserver<VoiceEnum>
{
    public GameSettings gameSettings;
    public Page[] PageArray;
    public Button btnNext;
    public Button btnPrev;
    public Button btnFin;
    public Text pageNumber;    
    public LanguageMenu languageMenu;
        
    private int currentPageIndex;    

    
    void Start()
    {
        gameSettings.Subscribe( this );
        currentPageIndex = 0;   //TODO properly update currentPageIndex with PlayerPref at the start of the program? (not sure if I really need to do this)
        CheckPageBounds();
        FormatPages();
        SetLanguageFromPref();
    }
   
    private void CheckPageBounds()
    {
        //**NOTE** this logic does not work with 2-page books!  Books must have 3 or more pages

        //check whether we are at the beginning or end of the book, then change the appropriate next/prev button  
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
        languageMenu.ChangeLanguageFromPlayerPref( language );
    }

    public void ChangeVoiceLanguage( int languageOption )
    {        
        for( int i = 0; i < PageArray.Length; i++ )        
        {            
            PageArray[i].ChangeVoiceLanguage( languageOption );
        }
        PlayerPrefs.SetInt( "Selected Language", languageOption );
    }

    public virtual void OnNext( VoiceEnum vEnum )
    {
        int languageOption = (int) vEnum;

        for ( int i = 0; i < PageArray.Length; i++ )
        {
            PageArray[i].ChangeVoiceLanguage( languageOption );
        }
        PlayerPrefs.SetInt( "Selected Language", languageOption );
    }

    public virtual void OnCompleted()
    {
        //no implementation
    }

    public virtual void OnError( Exception e )
    {
        //no implementation
    }

    public void NextPage()
    {
        int nextPageIndex = currentPageIndex + 1;

        if ( nextPageIndex < PageArray.Length )
        {            
            TurnPage( nextPageIndex );
        }
    }

    public void PrevPage()
    {
        int prevPageIndex = currentPageIndex - 1;

        if ( prevPageIndex >= 0 )
        {
            TurnPage( prevPageIndex );
        }
    }

    private void TurnPage( int nextPageIndex )
    {        
        //move the pages away from camera view
        RectTransform currentPageTransform = PageArray[currentPageIndex].GetComponent<RectTransform>();
        RectTransform nextPageTransform = PageArray[nextPageIndex].GetComponent<RectTransform>();

        float currentPageWidth = currentPageTransform.rect.width;
        float currentPageWidthDoubled = ( currentPageWidth * 2 );
        float nextPageWidth = nextPageTransform.rect.width;         

        currentPageTransform.SetInsetAndSizeFromParentEdge( RectTransform.Edge.Right, currentPageWidthDoubled, currentPageWidth );
        nextPageTransform.SetInsetAndSizeFromParentEdge( RectTransform.Edge.Left, 0, nextPageWidth );  
                
        PageArray[currentPageIndex].Deactivate();
        PageArray[nextPageIndex].Activate();

        //update the currentPage reference
        currentPageIndex = nextPageIndex;

        CheckPageBounds();
    }
    public int GetCurrentPageIndex()
    {
        return currentPageIndex;
    }   
}
