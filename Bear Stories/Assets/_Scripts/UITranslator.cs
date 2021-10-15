using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITranslator : MonoBehaviour
{
    public UITranslationText[] uiTexts;
    public void TranslateUIText( int language )
    {
        for( int i = 0; i < uiTexts.Length; i++ )
        {
            uiTexts[i].TranslateText( language );
        }
    }

}
