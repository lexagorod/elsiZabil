using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CommandManager : MonoBehavior
{
     
     private static CommandManager _instance;
     public static CommandManager instance
     {
         get
         {
             if (_instance == null)
             {
                 Debug.LogError("CM is null");
             }
                 return _instance;
             
         }
     }
     
     private void Awake()
     {
         _instance = this;
     }
     
     private List<ICommand> _commandBuffer = new List<ICommand>();
     
     public void AddCommand(ICommand comm)
     {
         _commandBuffer.Add(comm);
     }
     
     public void Rewind()
     {
         StartCoroutine(RewindRoutine());
     }
     
     IEnumerator RewindRoutine()
     {
         foreach (var command in Enumerable.Reverse(_commandBuffer))
         {
             command.Undue();
             yield return new WaitForEndOfFrame();
             
         }
         
     }
     
}
