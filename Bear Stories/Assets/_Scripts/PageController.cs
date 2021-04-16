﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class PageController : MonoBehaviour
{
    public Page[] PageArray;
    public Button btnNext;
    public Button btnPrev;
    public Toggle voiceToggle;
    public Text pageNumber;
    public AudioSource audioSource;


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
        currentPageIndex = 0;
        CheckPageBounds();
        FormatPages();
        if ( voiceToggle.isOn )
        {            
            PlayAutoVO();
        }
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
        for ( int i = 0; i < PageArray.Length; i++ )
        {
            PageArray[i].storyBox.FormatElements();
        }
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
        //deactivate the current page, and activate the next page
        PageArray[currentPageIndex].gameObject.SetActive( false );       
        PageArray[page].gameObject.SetActive( true );


        //update the currentPage reference
        currentPageIndex = page;

        if (voiceToggle.isOn)
        {            
            PlayAutoVO();
        }
        CheckPageBounds();
    }

    public int GetCurrentPageIndex()
    {
        return currentPageIndex;
    }


    public void PlayAutoVO()
    {
        Debug.Log("PlayAutoVO()");
        try
        {
            PageArray[currentPageIndex].PlaySelectedVoiceLines();
        }
        catch( NullReferenceException e )
        {
            Debug.Log( "PageController null reference" );            
        }        
    }
}
