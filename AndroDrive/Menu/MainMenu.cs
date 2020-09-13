using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class MainMenu : MonoBehaviour
{
    
    public GameObject controls;
    public GameObject controls2;
    void Start()
    {
        MusicManager.MM.Play();
        Cursor.lockState = CursorLockMode.Locked;
                   Cursor.visible = false; 
                   gameObject.transform.GetChild(0).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["play"][PlayerPrefs.GetString("language")]; 
                    gameObject.transform.GetChild(1).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["settings"][PlayerPrefs.GetString("language")]; 
                     gameObject.transform.GetChild(4).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["quit"][PlayerPrefs.GetString("language")]; 
                     gameObject.transform.GetChild(2).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["language"][PlayerPrefs.GetString("language")]; 
                     gameObject.transform.GetChild(3).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["credits"][PlayerPrefs.GetString("language")]; 
                      controls.transform.GetChild(3).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["inputText"][PlayerPrefs.GetString("language")]; 
                       controls2.transform.GetChild(1).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["recomm"][PlayerPrefs.GetString("language")]; 
                        controls2.transform.GetChild(2).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["ulti"][PlayerPrefs.GetString("language")]; 
                         controls2.transform.GetChild(3).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["attack"][PlayerPrefs.GetString("language")]; 
                            controls2.transform.GetChild(4).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["action"][PlayerPrefs.GetString("language")]; 
                             controls2.transform.GetChild(5).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["jumpAccept"][PlayerPrefs.GetString("language")]; 
                              controls2.transform.GetChild(6).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["dash"][PlayerPrefs.GetString("language")]; 
    }
    void Update()
    {
    
          if (EventSystem.current.currentSelectedGameObject != gameObject.transform.GetChild(0).gameObject &&
              EventSystem.current.currentSelectedGameObject != gameObject.transform.GetChild(1).gameObject && 
              EventSystem.current.currentSelectedGameObject != gameObject.transform.GetChild(2).gameObject &&
              EventSystem.current.currentSelectedGameObject != gameObject.transform.GetChild(3).gameObject &&
              EventSystem.current.currentSelectedGameObject != gameObject.transform.GetChild(4).gameObject)
                 {
                       EventSystem.current.SetSelectedGameObject(gameObject.transform.GetChild(0).gameObject);  
                 }
                 
      
         if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(GameManager.GM.accept) || Input.GetKeyUp(GameManager.GM.jumpJC)){
             EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();

        }
        
     
        
    }
    public void setLanguage()
    {
         if (PlayerPrefs.GetString("language", "Ru") == "Ru")
         {
              PlayerPrefs.SetString("language", "En");
         }
         else
         {
             PlayerPrefs.SetString("language", "Ru");
         }
         gameObject.transform.GetChild(0).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["play"][PlayerPrefs.GetString("language")]; 
                    gameObject.transform.GetChild(1).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["settings"][PlayerPrefs.GetString("language")]; 
                     gameObject.transform.GetChild(4).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["quit"][PlayerPrefs.GetString("language")]; 
                     gameObject.transform.GetChild(2).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["language"][PlayerPrefs.GetString("language")]; 
                      gameObject.transform.GetChild(3).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["credits"][PlayerPrefs.GetString("language")]; 
                       controls.transform.GetChild(3).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["inputText"][PlayerPrefs.GetString("language")]; 
                         controls2.transform.GetChild(1).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["recomm"][PlayerPrefs.GetString("language")]; 
                        controls2.transform.GetChild(2).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["ulti"][PlayerPrefs.GetString("language")]; 
                         controls2.transform.GetChild(3).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["attack"][PlayerPrefs.GetString("language")]; 
                            controls2.transform.GetChild(4).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["action"][PlayerPrefs.GetString("language")]; 
                             controls2.transform.GetChild(5).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["jumpAccept"][PlayerPrefs.GetString("language")]; 
                              controls2.transform.GetChild(6).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["dash"][PlayerPrefs.GetString("language")]; 
    }
    
    public void PlayGame()
    {
         DontDestroyOnLoad(MusicManager.MM);
        EventSystem.current.SetSelectedGameObject(null);
               SceneManager.LoadScene("Info");
        GameManager.GM.difficulty = 1;

    }
    
       
    public void PlayGameEasy()
    {
          DontDestroyOnLoad(MusicManager.MM);
        EventSystem.current.SetSelectedGameObject(null);
      //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       SceneManager.LoadScene("Info");
        GameManager.GM.difficulty = 0;
    }
    
       public void PlayGameHard()
    {
          DontDestroyOnLoad(MusicManager.MM);
        EventSystem.current.SetSelectedGameObject(null);
              SceneManager.LoadScene("Info");
        GameManager.GM.difficulty = 2;
    }
    
      public void Credits()
    {
          DontDestroyOnLoad(MusicManager.MM);
        EventSystem.current.SetSelectedGameObject(null);
              SceneManager.LoadScene(72);
    }
    
 
    
     public void Quit()
    {
        Application.Quit();
    }
}
