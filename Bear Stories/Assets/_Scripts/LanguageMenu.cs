using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using static UnityEditor.PlayerSettings.Switch;
#endif

public class LanguageMenu : MonoBehaviour
{
    public GameSettings gameSettings;    
    public PopupWindow popupWindow;    

    public Button engButton;
    public Button espButton;
    public Button deuButton;

    void Start()
    {        
        engButton.onClick.AddListener( () => ChangeLanguageWithButton( (int) VoiceEnum.ENGLISH ) );
        espButton.onClick.AddListener( () => ChangeLanguageWithButton( (int) VoiceEnum.ESPANOL ) );
        deuButton.onClick.AddListener( () => ChangeLanguageWithButton( (int) VoiceEnum.DEUTSCH ) );           
    }
    private void ChangeLanguageWithButton( int language )
    {
        gameSettings.CURRENT_LANGUAGE = ParseLanguageInt( language );
        popupWindow.ToggleWindow();
    }

    public void ChangeLanguageFromPlayerPref( int language )
    {
        gameSettings.CURRENT_LANGUAGE = ParseLanguageInt( language );
    }  

    private VoiceEnum ParseLanguageInt( int languagePref )
    {
        VoiceEnum language;

        switch ( languagePref )
        {
            case 0: //English
                language = VoiceEnum.ENGLISH;
                break;
            case 1:
                language = VoiceEnum.ESPANOL;
                break;
            case 2:
                language = VoiceEnum.DEUTSCH;
                break;
            default:
                Debug.Log( "Default Voice selected.  Setting to English" );
                language = VoiceEnum.ENGLISH;
                break;
        }
        return language;
    }    
}
