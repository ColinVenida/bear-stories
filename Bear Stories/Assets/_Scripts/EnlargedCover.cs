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
    public Canvas canvas;
    
    private int bookId;
    private Vector2 displayPoint = new Vector2 ( 0.0f, 0.0f );
    private Vector2 offScreenPoint;

    public void Start()
    {       
        float startY = this.GetComponent<RectTransform>().anchoredPosition.y;        
        offScreenPoint = new Vector2( 0.0f, startY );
    }

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

    public void MoveCoverIntoView()
    {        
        this.gameObject.GetComponent<RectTransform>().anchoredPosition = displayPoint;
    }

    public void HideCoverFromView()
    {                
        this.gameObject.GetComponent<RectTransform>().anchoredPosition = offScreenPoint;
    }

    public void SetBookId( int id )
    {
        bookId = id;
    }      
}
