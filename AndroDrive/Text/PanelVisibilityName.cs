using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class PanelVisibilityName : MonoBehaviour
{
    public static PanelVisibilityName panel;
    GameObject player, enter;
    public bool visible;
    
    void Awake()
    {
    visible = false;
    panel = this;
    showPanel(false);
    }

    
    void Update(){
      
        player = GameObject.FindWithTag("Player");
        panel.gameObject.transform.position = player.transform.position + new Vector3(2.5f, 2f,0);
        
       

        
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
 
