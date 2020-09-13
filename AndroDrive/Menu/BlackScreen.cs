 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;
 using UnityEngine.UI;
 using TMPro;
 
 public class BlackScreen : MonoBehaviour
 {
     [Header("Fade Out Script")]
     public Image logoImage;
     [Tooltip("Will start the fade out after value (in seconds)")]
     public float timeToStartFading = 1.75f;
     [Tooltip("Higher values = faster Fade Out")]
     public float fadeSpeed = 0.5f;
    // [Tooltip("Scene to Load (Must be stored in Builded Scenes Index -> File/Build Settings...)")]
   //  public int sceneToLoad = 1;
 
     public void Start()
     {
         //If you didn't drag the component
         if (logoImage == null)
             logoImage = gameObject.GetComponent<Image>();
         
     }
 
     public void Update()
     { 
   
         //Timer
         if (timeToStartFading > 0)
         {
             gameObject.transform.GetChild(0).gameObject.SetActive(false);
             timeToStartFading -= Time.deltaTime;
             return;
         }
        
         //Modify the color by changing alpha value
         logoImage.color = new Color(logoImage.color.r, logoImage.color.g, logoImage.color.b, logoImage.color.a + (fadeSpeed * Time.deltaTime));
         gameObject.transform.GetChild(0).gameObject.SetActive(true);
         //Basic scene change
       //  if (logoImage.color.a <= 0)
         //    SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
      
     }
  void OnDisable()
    {
        transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "";
           GameManager.GM.blackTextScreen = false;
    }
    
    void OnEnable()
    {
        GameManager.GM.blackTextScreen = true;
    }
 }