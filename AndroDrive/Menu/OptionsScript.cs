using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Update()
    {
       
          if (EventSystem.current.currentSelectedGameObject != gameObject.transform.GetChild(1).gameObject &&
              EventSystem.current.currentSelectedGameObject != gameObject.transform.GetChild(2).gameObject )
                 {
                       EventSystem.current.SetSelectedGameObject(gameObject.transform.GetChild(1).gameObject);  
                 }
                 
         if (Input.GetKeyUp(KeyCode.Return)){
             EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();

        }
    }
    
    
  
}
