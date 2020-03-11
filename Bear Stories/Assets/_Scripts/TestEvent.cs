using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to test animation events
public class TestEvent : MonoBehaviour
{

    public Animator animator;

    private bool animate = false;

    public void PrintAwesome()
    {
        Debug.Log( "Awesome!" );
        animator.SetBool("animate", false);
    }

    public void Magic()
    {
        animate = !animate;
        animator.SetBool("animate", true);
    }

}
