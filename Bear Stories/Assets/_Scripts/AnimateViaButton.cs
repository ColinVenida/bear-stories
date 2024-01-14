using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateViaButton : MonoBehaviour
{
    public Animator animator;
    public string stateName;

    public void PlayAnimation()
    {
        Debug.Log( "---AnimateViaButton Script---" );
        animator.Play( stateName );
    }
}
