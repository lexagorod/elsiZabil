using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehavior
{
    ICommand moveUp;
    [SerializedField]
    private float _speed = 2.0f;

     
     void Update()
     {
         if (Input.GetKey(KeyCode.W))
         {
             moveUp = new MoveUp(this.transform, _speed);
             moveUp.Execute();
             CommandManager.instance.AddCommand(moveUp);
         }
     }
     
}
