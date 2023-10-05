using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{

    public GameObject bolt;


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bolt, transform.position, transform.rotation); 
            //Destroy(bolt, 3);
        }
        
    }
}
