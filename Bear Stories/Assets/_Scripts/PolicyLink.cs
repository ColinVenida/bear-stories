using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyLink : MonoBehaviour
{
   public void OpenUnityPolicy()
   {
        Application.OpenURL( "https://unity3d.com/legal/privacy-policy" );
   }
}
