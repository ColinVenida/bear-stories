using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupWindow : MonoBehaviour 
{    
    private bool stopAnim = false;
    public bool shouldSwitchState;
    public GameObject window;
    
    //public Animator anim;
    
    public void ToggleWindow ()
    {   
        //animation stuff here??
        window.SetActive( !window.activeSelf );
        if ( shouldSwitchState )
        {
            this.gameObject.SetActive( !this.gameObject.activeSelf );
        }
    }	
}
