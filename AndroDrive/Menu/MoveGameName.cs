using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MoveGameName : MonoBehaviour
{
    
    Vector3 start;
    public Transform end;
    private float startTime;
    public float speed = 0.5f;
    bool moving = false;
    bool lightUp;
    bool showUp;
    bool onetime;
    bool onetime2;
    bool epilep;
    public GameObject menu;
    public SpriteRenderer logoImage;
    public GameObject textRu, textEn, controls;
    GameObject text;
    float timerEpilep = 4.5f;
    
    // Start is called before the first frame update
    void Start()
    {
         if (Application.systemLanguage == SystemLanguage.Russian)
        {
            text = textRu;
        }
        else
        {
            text = textEn;
        }
        
        text.SetActive(true);
       
    }

    // Update is called once per frame
    void Update()
    {
      
      if (text.activeSelf)
      {
           timerEpilep -= Time.deltaTime;
      }
      if (timerEpilep <0 && !epilep)
      {
          epilep =true;
        text.SetActive(false);
        startTime = Time.time;
        start = transform.position;
        moving = true;
      }

     if (moving) 
    {
        float timePast = Time.time - startTime; 
        float distanceCovered = timePast * speed; 
 
        transform.position = Vector3.Lerp(start, end.position, distanceCovered); 
        if (distanceCovered >0.05)
        {
            if (!onetime)
            {
            SoundManager.SM.PlaySound("swingAir");
            onetime = true;
            }
        }
        if (distanceCovered >= 1)
        {
            moving = false;
            lightUp = true;
        }
    }
     if (lightUp)
     {
          if (!onetime2)
            {
               SoundManager.SM.PlaySound("powerUP");
               onetime2 = true;
            }
         logoImage.color = new Color(logoImage.color.r  + (0.5f * Time.deltaTime), logoImage.color.g  + (0.5f * Time.deltaTime), logoImage.color.b + (0.5f * Time.deltaTime), logoImage.color.a);
         if (logoImage.color.r >= 1f)
         {
             lightUp = false;
             showUp = true;
         }
     }
     if (showUp)
     {
         menu.SetActive(true);
         controls.SetActive(true);
         showUp = false;
     }
    }
}
