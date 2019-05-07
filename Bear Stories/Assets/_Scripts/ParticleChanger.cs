using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleChanger : MonoBehaviour
{
    public Dropdown particleDrop;
    //public Image icon;
    public Texture[] partTextures;
    public ParticleSystem partSystem;
    public ParticleSystemRenderer partRend;

    //private bool isOn = true;

    public void ChangeParticle( int selection )
    {
        //particleDrop.
        switch( selection)
        {
            case 0:
                partRend.enabled = true;
                partRend.material.mainTexture = partTextures[0];
                break;
            case 1:
                partRend.enabled = true;
                partRend.material.mainTexture = partTextures[1];
                break;
            case 2: //off
                partRend.enabled = false;
                break;
            default:
                break;
        }   //end switch
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
