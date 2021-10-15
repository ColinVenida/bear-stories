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

    private void Start()
    {        
        coverImage = this.GetComponent<Image>();
    }

    public void ShowCover()
    {        
        enlargedCover.MoveCoverIntoView();
        enlargedCover.cover.sprite = coverImage.sprite;
        enlargedCover.SetBookId( bookId );
    }

    public void UpdateCover()
    {
        enlargedCover.cover.sprite = coverImage.sprite;
    }   
}
