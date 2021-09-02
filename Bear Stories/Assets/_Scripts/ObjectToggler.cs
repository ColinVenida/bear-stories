using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToggler : MonoBehaviour
{
    public GameObject obj;

    public void ToggleObject()
    {
        obj.SetActive( !obj.activeSelf );
    }
}
