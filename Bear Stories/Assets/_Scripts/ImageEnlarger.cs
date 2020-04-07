using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//class that enlarges the book cover when it's clicked
public class ImageEnlarger : MonoBehaviour
{

    //public Image enlargedCover;
    public EnlargedCover enlargedCover;
    public int bookId;

    private Image coverImage;
    private bool isEnlarged = false;

    UnityEvent enlargeCover = new UnityEvent();
   
    public void Enlarge()
    {        
        enlargeCover.Invoke();        
    }

    void ShowCover()
    {
        //isEnlarged = !isEnlarged;

        ////activate the enlargedCover and set the sprite
        //if (isEnlarged)
        //{
        //    enlargedCover.cover.gameObject.SetActive( true );
        //    enlargedCover.cover.sprite = coverImage.sprite;
        //    enlargedCover.SetBookId( bookId );
        //}
        //else
        //{
        //    enlargedCover.cover.gameObject.SetActive( false );
        //    enlargedCover.cover.sprite = null;
        //}
               
        //activate the enlargedCover and set the sprite       
        enlargedCover.cover.gameObject.SetActive( true );
        enlargedCover.cover.sprite = coverImage.sprite;
        enlargedCover.SetBookId( bookId );
    }

    private void Start()
    {        
        enlargeCover.AddListener( ShowCover );
        coverImage = this.GetComponent<Image>();
    }
}
