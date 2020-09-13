using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;


public class LoadPlay : MonoBehaviour
{
      void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
          gameObject.transform.GetChild(0).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["loadGame"][PlayerPrefs.GetString("language")]; 
                    gameObject.transform.GetChild(1).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["newGame"][PlayerPrefs.GetString("language")]; 
                     gameObject.transform.GetChild(2).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["goback"][PlayerPrefs.GetString("language")]; 
    }
    void Update()
    {
        string path = Application.dataPath + "/saveData.lil";
        if (!File.Exists(path))
        {
            gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(255, 128, 0, 255);
           
           if (
              EventSystem.current.currentSelectedGameObject != gameObject.transform.GetChild(1).gameObject && 
              EventSystem.current.currentSelectedGameObject != gameObject.transform.GetChild(2).gameObject)
                 {
       
                     EventSystem.current.SetSelectedGameObject(gameObject.transform.GetChild(1).gameObject); 

                 }
        }
        else {
       
          if (EventSystem.current.currentSelectedGameObject != gameObject.transform.GetChild(0).gameObject &&
              EventSystem.current.currentSelectedGameObject != gameObject.transform.GetChild(1).gameObject && 
              EventSystem.current.currentSelectedGameObject != gameObject.transform.GetChild(2).gameObject)
                 {
       
                     EventSystem.current.SetSelectedGameObject(gameObject.transform.GetChild(0).gameObject); 

                 }
        }
      
         if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(GameManager.GM.accept)  || Input.GetKeyUp(GameManager.GM.jumpJC)){
             EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
             
         }
         
       

        
    }
    void OnEnable()
    {
          gameObject.transform.GetChild(0).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["loadGame"][PlayerPrefs.GetString("language")]; 
                    gameObject.transform.GetChild(1).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["newGame"][PlayerPrefs.GetString("language")]; 
                     gameObject.transform.GetChild(2).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["goback"][PlayerPrefs.GetString("language")]; 
    }
    
       public void LoadGame()
    
    {  
      
       if (SaveSystem.LoadPlayer().level >=16 && SaveSystem.LoadPlayer().level !=70 &&  SaveSystem.LoadPlayer().level !=71 )
         {
            PlayerPrefs.SetInt("Spacing", 1);
        }
        else
        {
             PlayerPrefs.SetInt("Spacing", 0);
        }
         MusicManager.MM.Stop();
        GameManager.GM.load = true;
        GameManager.GM.lifeNumber = SaveSystem.LoadPlayer().lifeNumber;
        GameManager.GM.numberofPills = SaveSystem.LoadPlayer().pillsNumber;
        GameManager.GM.fishFeed = SaveSystem.LoadPlayer().fishFeed;
        GameManager.GM.strangeTalking = SaveSystem.LoadPlayer().strangeTalking;
        GameManager.GM.difficulty = SaveSystem.LoadPlayer().difficulty;
        GameManager.GM.releaseScientist = SaveSystem.LoadPlayer().releaseScientist;
        GameManager.GM.kidNarkotik = SaveSystem.LoadPlayer().kidNarkotik;
        GameManager.GM.erdonit = SaveSystem.LoadPlayer().erdonit;
        GameManager.GM.knowTheTruth = SaveSystem.LoadPlayer().knowTheTruth;
        GameManager.GM.agree = SaveSystem.LoadPlayer().agree;
        GameManager.GM.juliaAgree = SaveSystem.LoadPlayer().juliaAgree;
        GameManager.GM.goSave =  SaveSystem.LoadPlayer().goSave;
        GameManager.GM.gameMode =  SaveSystem.LoadPlayer().gameMode;
        GameManager.GM.levelRevive =  SaveSystem.LoadPlayer().levelRevive;
        GameManager.GM.jokes =  SaveSystem.LoadPlayer().jokes;
        GameManager.GM.captainAgreeAnswer = SaveSystem.LoadPlayer().captainAgreeAnswer;
        EventSystem.current.SetSelectedGameObject(null);
        SceneManager.LoadScene( SaveSystem.LoadPlayer().level);
 
       // Cursor.lockState = CursorLockMode.None;
       
       
        
    }
}
