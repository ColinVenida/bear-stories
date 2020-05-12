using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PageController : MonoBehaviour
{

    public GameObject[] PageArray;
    public Button btnNext;
    public Button btnPrev;

    public Text pageNumber;
    private int currentPage;    

    public void NextPage()
    {
        //check array bounds here
        if ( currentPage + 1 < PageArray.Length )
        {            
            TurnPage( currentPage + 1 );
        }
    }

    public void PrevPage()
    {
        if ( currentPage - 1 >= 0 )
        {
            TurnPage( currentPage - 1 );
        }
    }

    private void TurnPage( int page )
    {        
        //deactivate the current page, and activate the next page
        PageArray[currentPage].gameObject.SetActive( false );       
        PageArray[page].gameObject.SetActive( true );
  
        //update the currentPage reference
        currentPage = page;
        CheckPageBounds();
    }

    private void CheckPageBounds()
    {
        //check whether we are at the beginning or end of the book, then turn off the appropriate next/prev button

        //Debug.Log( "CheckPageBounds() currentPage == " + currentPage );
        //**NOTE** this logic does not work with 2-page books!  Books must have 3 or more pages
        if (currentPage == 0)
        {
            btnPrev.gameObject.SetActive( false );           
        }
        else if (currentPage == PageArray.Length - 1)
        {
            btnNext.gameObject.SetActive( false );            
        }
        else
        {
            btnNext.gameObject.SetActive( true );
            btnPrev.gameObject.SetActive( true );
        }

        //update the page number
        pageNumber.text = ( (currentPage + 1).ToString() + "/" + PageArray.Length.ToString() );

    }

    public void FormatPages()
    {
        //format all the pages to the UI elements fit in the box
        for( int i = 0; i < PageArray.Length; i++ )        
        {            
            PageArray[i].GetComponentInChildren<StoryBox>().Invoke( "FormatElements", 0 );
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        currentPage = 0;
        CheckPageBounds();
        FormatPages();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
