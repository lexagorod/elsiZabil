using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class PanelVisibility : MonoBehaviour
{
    public static PanelVisibility panel;
    GameObject player, enter;
    public bool visible;
    
    void Awake()
    {
    visible = false;
    panel = this;
    showPanel(false);
    }

    
    void Update(){
      
    
        if (player !=null)
        {
            if (PlayerPrefs.GetInt("Spacing") == 1)
            {
                  
                  transform.position =  Camera.main.transform.position + new Vector3(0, 0.5f, 50f);
            }
            else
            {
            transform.position = player.transform.position + new Vector3(2.5f, 1f,0);
            }
   
        }
        else
        {
              if (PlayerPrefs.GetInt("Spacing") == 1)
            {  player = GameObject.FindWithTag("truck");}
        else
        {
                player = GameObject.FindWithTag("Player");
        }
         if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
               
        }
       
       

        
    }
    
    
    public void showPanel(bool visibility){
        visible = visibility;
           
        if (visibility){
        panel.gameObject.SetActive (true);
        //   GameManager.GM.inputOn = true;
  
       }
        else 
        {                

         panel.gameObject.SetActive (false);
            
   
        }
        
        
    }
    
 
}
 
