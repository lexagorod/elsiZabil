using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp: ICommand
{
    private Transform _player;
    private float _speed;
    
    public MoveUp(Transform player, float speed)
    {
        this._player = player;
        this._speed = speed;
    }
     public void Execute()
     {
        _player.Translate(Vector3.up * _speed * Time.deltaTime); 
     }
     
     public void Undue()
     {
          _player.Translate(Vector3.down * _speed * Time.deltaTime); 
     }
}
