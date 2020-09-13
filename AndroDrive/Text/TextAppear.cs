using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
 
 public class TextAppear : MonoBehaviour {
 
     public float textSpeed;
   //  public AudioClip typeSound1;
    // public AudioClip typeSound2;
 
   
     TextMeshProUGUI textComp;
     List<int> bigChar;
     
     // Use this for initialization
     void Awake () {
         textComp = GetComponent<TextMeshProUGUI>();
         textComp.text = "";
         
        
     }
     
     public void clear(){
       textComp.text = "";
     }
     
     public void setTextInstant(string message)
     {
         
          GameManager.GM.textStop = true;
         StartCoroutine(textoff());
          textComp.text = message; 
     }
     
     IEnumerator textoff()
     {
          yield return new WaitForSeconds (0.47f);
         GameManager.GM.textRunning = false;
         yield return new WaitForSeconds (0.1f);
          GameManager.GM.readyForSkip = true;
     }
     
     void OnDisable()
     {
         if (GameManager.GM != null)
         {
          GameManager.GM.readyForSkip = true;
         }
     }
 
     public IEnumerator TypeText (string message, List<int> bigChar = null) {
         
         GameManager.GM.textRunning = true;
          GameManager.GM.textStop = false;
             textComp.text = "";
      if (PlayerPrefs.GetString("language","Ru") == "Ru")
       {  
     
         for (int i = 0; i< message.ToCharArray().Length; i++) 
         {
       
   
             if (bigChar != null && bigChar.Contains(i))
              {
                 
                // textComp.text += char.ToUpper(message.ToCharArray()[i]);
                 textComp.text += message.ToCharArray()[i];
                 GameManager.GM.textStop = true;
                 yield return new WaitForSeconds (1f);

                         GameManager.GM.textStop = false;
              }
              else
              {

                  if (message.ToCharArray()[i].ToString() == "<")
                  {
                      int fr = message.IndexOf("<");
                      int to = message.LastIndexOf(">") + 1;
                      string temp = message.Substring(fr, to - fr);
                      textComp.text += temp;
                      i = to -1;
                  }
                  else
                  {
                        textComp.text += message.ToCharArray()[i];
                  }
                 yield return new WaitForSeconds (textSpeed);
              }
 
        
         }
       }
       else
       {
               for (int i = 0; i< message.ToCharArray().Length; i++) 
         {
       
   
             if (message.ToCharArray()[i].ToString().Contains("$"))
              {
                 
                // textComp.text += char.ToUpper(message.ToCharArray()[i]);
               //  textComp.text += message.ToCharArray()[i];
                 GameManager.GM.textStop = true;
                 yield return new WaitForSeconds (1f);
                         GameManager.GM.textStop = false;
              }
              else
              {

                  if (message.ToCharArray()[i].ToString() == "<")
                  {
                      int fr = message.IndexOf("<");
                      int to = message.LastIndexOf(">") + 1;
                      string temp = message.Substring(fr, to - fr);
                      textComp.text += temp;
                      i = to -1;
                  }
                  else
                  {
                        textComp.text += message.ToCharArray()[i];
                  }
                 yield return new WaitForSeconds (textSpeed);
              }
 
        
         }
       }
           GameManager.GM.textStop = true;
          GameManager.GM.textRunning = false;
          
          
     }
 }