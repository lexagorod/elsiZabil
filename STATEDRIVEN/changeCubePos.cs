using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCubePos : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
       Main.onClick += changePos;   
    }
    
    void changePos()
    {
        transform.position = new Vector3(5,2,0);
    }
}
