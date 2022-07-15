using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationDebugger : MonoBehaviour
{

    public Text uiText;
    
    
    public void DisplayStart()
    {
        Debug.Log( "animation start" );
        uiText.text = "animation start!";
    }

    public void DisplayEnd()
    {
        Debug.Log( "animation end" );
        uiText.text = "animation end!";
    }
}
