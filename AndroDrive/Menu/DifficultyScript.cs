using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DifficultyScript : MonoBehaviour
{
    // Start is called before the first frame update
       void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
          gameObject.transform.GetChild(0).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["easy"][PlayerPrefs.GetString("language")]; 
                    gameObject.transform.GetChild(1).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["normal"][PlayerPrefs.GetString("language")]; 
                    gameObject.transform.GetChild(2).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["hard"][PlayerPrefs.GetString("language")]; 
                     gameObject.transform.GetChild(3).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["goback"][PlayerPrefs.GetString("language")]; 
                     gameObject.transform.GetChild(4).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["difficulty"][PlayerPrefs.GetString("language")]; 
                      gameObject.transform.GetChild(5).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["lives100"][PlayerPrefs.GetString("language")]; 
                       gameObject.transform.GetChild(6).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["lives50"][PlayerPrefs.GetString("language")]; 
                         gameObject.transform.GetChild(7).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["lives10"][PlayerPrefs.GetString("language")]; 
    }
    void Update()
    {
       
          if (EventSystem.current.currentSelectedGameObject != gameObject.transform.GetChild(0).gameObject &&
              EventSystem.current.currentSelectedGameObject != gameObject.transform.GetChild(1).gameObject &&
              EventSystem.current.currentSelectedGameObject != gameObject.transform.GetChild(2).gameObject &&
              EventSystem.current.currentSelectedGameObject != gameObject.transform.GetChild(3).gameObject)
                 {
                       EventSystem.current.SetSelectedGameObject(gameObject.transform.GetChild(0).gameObject);  
                 }
                 
            if (EventSystem.current.currentSelectedGameObject == gameObject.transform.GetChild(0).gameObject)
            {
                gameObject.transform.GetChild(4).position = new Vector3(gameObject.transform.GetChild(4).position.x, gameObject.transform.GetChild(0).position.y, gameObject.transform.GetChild(4).position.z);
                gameObject.transform.GetChild(5).gameObject.SetActive(true);
                gameObject.transform.GetChild(6).gameObject.SetActive(false);
                 gameObject.transform.GetChild(7).gameObject.SetActive(false);
            }
            else if (EventSystem.current.currentSelectedGameObject == gameObject.transform.GetChild(1).gameObject)
            {
                 gameObject.transform.GetChild(4).position = new Vector3(gameObject.transform.GetChild(4).position.x, gameObject.transform.GetChild(1).position.y, gameObject.transform.GetChild(4).position.z);
                    gameObject.transform.GetChild(5).gameObject.SetActive(false);
                gameObject.transform.GetChild(6).gameObject.SetActive(true);
                 gameObject.transform.GetChild(7).gameObject.SetActive(false);
            }
             else if (EventSystem.current.currentSelectedGameObject == gameObject.transform.GetChild(2).gameObject)
            {
                 gameObject.transform.GetChild(4).position = new Vector3(gameObject.transform.GetChild(4).position.x, gameObject.transform.GetChild(2).position.y, gameObject.transform.GetChild(4).position.z);
                    gameObject.transform.GetChild(5).gameObject.SetActive(false);
                gameObject.transform.GetChild(6).gameObject.SetActive(false);
                 gameObject.transform.GetChild(7).gameObject.SetActive(true);
            }
            else
            {
                   gameObject.transform.GetChild(5).gameObject.SetActive(false);
                  gameObject.transform.GetChild(6).gameObject.SetActive(false);
                gameObject.transform.GetChild(7).gameObject.SetActive(false);
            }
                 
         if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(GameManager.GM.accept)  || Input.GetKeyUp(GameManager.GM.jumpJC)){
             EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();

        }
    }
    void OnEnable()
    {
        gameObject.transform.GetChild(0).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["easy"][PlayerPrefs.GetString("language")]; 
                    gameObject.transform.GetChild(1).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["normal"][PlayerPrefs.GetString("language")]; 
                    gameObject.transform.GetChild(2).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["hard"][PlayerPrefs.GetString("language")]; 
                     gameObject.transform.GetChild(3).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["goback"][PlayerPrefs.GetString("language")]; 
                     gameObject.transform.GetChild(4).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["difficulty"][PlayerPrefs.GetString("language")]; 
                      gameObject.transform.GetChild(5).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["lives100"][PlayerPrefs.GetString("language")]; 
                       gameObject.transform.GetChild(6).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["lives50"][PlayerPrefs.GetString("language")]; 
                         gameObject.transform.GetChild(7).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["lives10"][PlayerPrefs.GetString("language")];   
    }
    
    
  
}
