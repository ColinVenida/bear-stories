using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj; //the GameObject/prefab to spawn
    public Canvas canvasParent;
    public int initial;     //how many objects to spawn at Start()
    public float rate;      //how fast we spawn our objects

    public int x;
    public int y;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initial; i++)
        {
            //Instantiate( obj, new Vector3( 0.0f, 0.0f ), new Quaternion() );            
            Instantiate( obj, canvasParent.transform );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
