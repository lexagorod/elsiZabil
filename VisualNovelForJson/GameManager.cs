using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    
    [SerializeField]
    private PHASES _phases;
    public delegate void Action();
    public Action action;
    public GameObject character, mask, RI;
    public Material M;
    Image rendererI;
     
    public enum PHASES
    {
        
      NOSPRITE, SHOWSPRITE 
      
    };


    void Awake()
    {
        GM = this;
    }
    
    void Start()
    {
        action = sprite;
        rendererI = (Image)character.transform.GetChild(1).gameObject.GetComponent(typeof(Image));
    }
    
    public PHASES getState()
    {
        return _phases;
    }

    public void setState(PHASES name)
    {
        _phases = name;
    }
    
    public void callAction()
    {
        action();
    }
    
    public void sprite()
    {
        rendererI.material = M;
       _phases = PHASES.SHOWSPRITE;
       DialogueManager.DM.Say();
        DialogueManager.DM.setText("ДАЛЕЕ");
       action = changeFace; 
       character.SetActive(true);
       mask.SetActive(true);
    }
    
    public void changeFace()
    {
        RI.SetActive(true);
        APIController.API.OnButtonImage();
        rendererI.material = null;
        DialogueManager.DM.Say();
        action = noSprite; 
         DialogueManager.DM.setText("СЦЕНА 1");
    }
    
    public void noSprite()
    {
        RI.SetActive(false);
        DialogueManager.DM.index = 0;
        action = sprite; 
       _phases = PHASES.NOSPRITE;
       mask.SetActive(false);
      DialogueManager.DM.speechPanel.SetActive(false);
      DialogueManager.DM.setText("СЦЕНА 2");
        
    }
}
