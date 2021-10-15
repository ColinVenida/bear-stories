using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageMenu : MonoBehaviour
{
    public Book book;
    public PageController pageController;
    public UITranslator uiTranslator;
    public PopupWindow popupWindow;
    public ImageSwaper titlePage_imageSwaper;

    public Button engButton;
    public Button espButton;
    public Button deuButton;
    
    private enum Language 
    {
        ENGLISH = 0,
        ESPANOL = 1,
        DEUTCH = 2
    }

    void Start()
    {
        engButton.onClick.AddListener( () => ChangeLanguageWithButton( (int) Language.ENGLISH ) );
        espButton.onClick.AddListener( () => ChangeLanguageWithButton( (int) Language.ESPANOL ) );
        deuButton.onClick.AddListener( () => ChangeLanguageWithButton( (int) Language.DEUTCH ) );        
    }

    public void ChangeLanguageFromPlayerPref( int language )
    {
        book.ChangeLanguageText( language );
        pageController.ChangeVoiceLanguage( language );
        pageController.FormatPages();
        titlePage_imageSwaper.SwapImageWithIndex( language );
    }

    private void ChangeLanguageWithButton( int language )
    {        
        book.ChangeLanguageText( language );
        pageController.ChangeVoiceLanguage( language );
        uiTranslator.TranslateUIText( language );
        pageController.FormatPages();
        titlePage_imageSwaper.SwapImageWithIndex( language );
        popupWindow.ToggleWindow();
    }    
}
