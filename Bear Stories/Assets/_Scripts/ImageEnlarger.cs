using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//class that enlarges the book cover when it's clicked
public class ImageEnlarger : MonoBehaviour
{   
    public EnlargedCover enlargedCover;
    public int bookId;

    private Image coverImage;    

    UnityEvent enlargeCover = new UnityEvent();
   
    public void Enlarge()
    {        
        enlargeCover.Invoke();        
    }

    void ShowCover()
    {               
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
