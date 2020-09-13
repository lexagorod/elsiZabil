using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPanelVisibility : MonoBehaviour
{
 public static AnswerPanelVisibility panel;
 static Animator animator;
public bool visible;
 
    
    void Awake()
    {
    panel = this;
    visible = false;
    
    }
    
    
    
    public void showPanel(bool visibility){
        
        visible = visibility;
         if (visibility){
        panel.gameObject.SetActive (true);
  
       }
        else 
        {                
         panel.gameObject.SetActive (false);
   
        }
        
    }
}
