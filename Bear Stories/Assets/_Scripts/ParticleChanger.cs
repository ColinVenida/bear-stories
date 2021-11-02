using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//**Test class for changing particles in  the scene***
public class ParticleChanger : MonoBehaviour
{
    public Dropdown particleDrop;    
    public Texture[] partTextures;   
    public ParticleSystemRenderer partRend;
    public ParticleSystem partSystem;
    public Image sky;


    public void ChangeParticle( int selection )
    {
        //particleDrop.
        switch( selection)
        {
            case 0:  //sun                
                partSystem.Stop();
                sky.color = new Color32( 154, 217, 245, 255 );
                break;                
            case 1:  //rain                   
                sky.color = new Color32( 161, 181, 191, 255 );
                partRend.material.mainTexture = partTextures[0];                
                partSystem.Play();
                break;                
            case 2: //snow                
                sky.color = new Color32( 112, 128, 135, 255 );
                partRend.material.mainTexture = partTextures[1];
                partSystem.Play();
                break;
            default:
                break;
        }   //end switch
    }

    private void Start()
    {
        partSystem.Stop(); 
    }   
}
