using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnlargedCover : MonoBehaviour
{
    public Image cover;
    public Button closeBtn;
    public Button readBtn;
    
    private int bookId;

    public void ReadBook()
    {
        //switch the scene based on the bookId
        switch( bookId )
        {
            case 0:
                SceneManager.LoadScene( "Bongo" );
                break;
            case 1:
               SceneManager.LoadScene( "TestScene" );
               break;
            //case 2:
            //    break;           
            default:
                Debug.Log( "bookId not set.  bookId = " + bookId );
                break;
        }
    }

    public void CloseCover()
    {
        this.gameObject.SetActive( false );
    }

    public void SetBookId( int id )
    {
        bookId = id;
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
