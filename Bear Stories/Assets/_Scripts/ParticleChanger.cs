using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleChanger : MonoBehaviour
{
    public Dropdown particleDrop;    
    public Texture[] partTextures;   
    public ParticleSystemRenderer partRend;
    public Image sky;


    public void ChangeParticle( int selection )
    {
        //particleDrop.
        switch( selection)
        {
            case 0:
                partRend.enabled = true;
                sky.color = new Color32( 161, 181, 191, 255 );
                partRend.material.mainTexture = partTextures[0];
                break;
            case 1:
                partRend.enabled = true;
                sky.color = new Color32( 112, 128, 135, 255 );
                partRend.material.mainTexture = partTextures[1];
                break;
            case 2: //off
                partRend.enabled = false;
                sky.color = new Color32( 154, 217, 245, 255 );                
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
