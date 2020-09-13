using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LOLMath : MonoBehaviour
{
   public Func<int> Sum;
     
     
        void Start()
        {
        Sum = () => gameObject.name.Length;
               
           Debug.Log(Sum());
        
        }
}
