using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTurner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prevPage;
    public GameObject currentPage;
    public GameObject nextPage;

    public void NextPage()
    {
        if ( nextPage != null )
        {           
            nextPage.gameObject.SetActive( true );
            currentPage.gameObject.SetActive( false );
        }        
    }

    public void PrevPage()
    {
        if ( prevPage != null)
        {
            prevPage.gameObject.SetActive( true );
            currentPage.gameObject.SetActive( false );
        }            
    }

}
