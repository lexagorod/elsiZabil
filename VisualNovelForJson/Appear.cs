using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Appear : MonoBehaviour
{

    public Transform targetPos;
    Vector3 startPos;
    public float speed = 1000f;
    private float startTime;
    private float journeyLength;
    bool resetted = true;

    void Start()
    {    
       startPos = transform.position;
       journeyLength = Vector2.Distance(startPos, targetPos.position);
       reset();  
    }
    
    void reset()
    {
          startTime = Time.time;
          transform.position = startPos;
    }
    
    void Update()
    {
        if (GameManager.GM.getState() == GameManager.PHASES.SHOWSPRITE)
        {
            if (!resetted)
            {
                reset();
                resetted = true;
            }
            float distCovered = (Time.time - startTime) * speed;
         
         
            float fractionOfJourney = distCovered / journeyLength;
 
            transform.position = Vector2.Lerp(startPos, targetPos.position, fractionOfJourney);
            

        }
        else
        {
            if (resetted)
            {
                resetted = false;
                reset();
            }
            gameObject.SetActive(false);
        }
    }


}
