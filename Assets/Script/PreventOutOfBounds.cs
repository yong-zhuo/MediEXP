using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z >= 5.16f){
            transform.position = new Vector3(0,0,5.16f);
        }
        if(transform.position.z <= -3.7f){
            transform.position = new Vector3(transform.position.x,transform.position.y,-3.7f);
        }
        if(transform.position.y <= -1.5f){
            transform.position = new Vector3(transform.position.x,-1.4f, transform.position.z);
        
        }
        if(transform.position.y >= 3.93f){
            transform.position = new Vector3(transform.position.x, 3.92f,transform.position.z);
        
        }
        if(transform.position.x >= 2.43f){
            transform.position = new Vector3(2.42f, transform.position.y ,transform.position.z);
        
        }
        if(transform.position.x <= -4.62f){
            transform.position = new Vector3(-4.61f, transform.position.y ,transform.position.z);
        
        }
    }
}
