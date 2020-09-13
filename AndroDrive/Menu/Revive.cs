using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Revive : MonoBehaviour
{
    public static Revive rv;
    
    public GameObject BS;
    public GameObject capsule;
    public GameObject player;
    GameObject playerDum, temporaryMan;
    public Vector3 position;
    public GameObject mechnickEasy, shooteR, swordMan,mechnickEasyP,shooteRP,swordManP, turret, yogi, yogiP, droidBehave, droidBehaveP;
    CameraFollow cameraFollow;
    public List<GameObject> allEnemies;
    List<GameObject> allEnemiesDeath;
    int enemyNumber;
    bool ressurected;
    List<Vector3> distances;
    List<bool> patrol;
    List<int> choices;
    int levelReviveN;
    
    void Awake()
    {
        rv = this;
    }
    
    void Start()
    {  allEnemies = new List<GameObject>();
       allEnemiesDeath = new List<GameObject>();
       DoCheckEnemyPositions() ;
       choices = new List<int>();
       choices.Add(-1);
       choices.Add(1);
    }
  
    public void NewPlayer()
    {
         StartCoroutine(CreateNewPlayer());
    }
       
    IEnumerator CreateNewPlayer()
    {
        
     if (GameManager.GM.lifeNumber > -1)
     {
    


      
      if (PlayerPrefs.GetInt("Underground") != 2)
       {
       yield return new WaitForSeconds(1f); 
       BS.SetActive(true);
         // StartCoroutine( BS.transform.GetChild(0).gameObject.GetComponent<TextAppear>().TypeText (""));
         yield return new WaitForSeconds(1.75f);
       StartCoroutine( BS.transform.GetChild(0).gameObject.GetComponent<TextAppear>().TypeText (ImportText.allPhrases["NewLaunch"][PlayerPrefs.GetString("language")]));
       yield return new WaitForSeconds(1.75f);
       }       
       var myRandomIndex = Random.Range( 0, choices.Count);
        GameObject[] particle = GameObject.FindGameObjectsWithTag("corpse");
  
       int NotNull = 10;
       while (NotNull > 6)    
       {        NotNull = 0;
        
                  foreach(var ps in particle)
                  {
                      myRandomIndex = Random.Range( 0, 2);
                      if (myRandomIndex == 1)
                      {
                      Destroy(ps);
                      }
                      else
                      {
                          NotNull += 1;
                      }
                  }
           
       }
       switch(PlayerPrefs.GetInt("Revive"))
          {
         
           case 0:
           
       allEnemiesDeath = new List<GameObject>();
       allEnemiesDeath = allEnemies;
       allEnemies = new List<GameObject>();
       
     

    
       
       if((float)GameObject.FindGameObjectsWithTag("EnemyEasy").Length/enemyNumber >= 0.5)
        { 
         if (allEnemiesDeath.Count != 0)
            {
            for(var enemy = 0; enemy < allEnemiesDeath.Count; enemy ++)
                {
                  if (allEnemiesDeath[enemy] != null)
                  {
                   
                   if(allEnemiesDeath[enemy].GetComponent<FollowBehave>() != null)
                   {
                       myRandomIndex = Random.Range( 0, choices.Count);
                       if (patrol[enemy])
                       {
                            temporaryMan = Instantiate(mechnickEasyP, distances[enemy], mechnickEasyP.transform.rotation);
                       }
                       else
                       {
                       temporaryMan = Instantiate(mechnickEasy, distances[enemy], mechnickEasy.transform.rotation);
                       }
                       temporaryMan.transform.localScale = new Vector3 (temporaryMan.transform.localScale.x * choices[myRandomIndex], temporaryMan.transform.localScale.y,0);
                       allEnemies.Add(temporaryMan);
                       temporaryMan.GetComponent<MechPhys>().stand();
                       Destroy(allEnemiesDeath[enemy]);
                   }
                   else if (allEnemiesDeath[enemy].GetComponent<EasyGunnerFollow>() != null)
                   {
                       myRandomIndex = Random.Range( 0, choices.Count);
                        if (patrol[enemy])
                       {
                          temporaryMan = Instantiate(shooteRP, distances[enemy], shooteRP.transform.rotation);
                       }
                       else
                       {
                       temporaryMan = Instantiate(shooteR, distances[enemy], shooteR.transform.rotation);
                       }
                       
                       temporaryMan.transform.localScale = new Vector3 (temporaryMan.transform.localScale.x * choices[myRandomIndex], temporaryMan.transform.localScale.y,0);
                       allEnemies.Add(temporaryMan);
                        temporaryMan.GetComponent<MechPhys>().stand();
                        Destroy(allEnemiesDeath[enemy]);
                   }  
                   else if (allEnemiesDeath[enemy].GetComponent<FollowBehaveSwordman>() != null)
                   {
                       myRandomIndex = Random.Range( 0, choices.Count);
                        if (patrol[enemy])
                       {
                           temporaryMan = Instantiate(swordManP, distances[enemy], swordManP.transform.rotation);
                       }
                        else
                       {
                          temporaryMan = Instantiate(swordMan, distances[enemy], swordMan.transform.rotation);
                       }
                      
                       temporaryMan.transform.localScale = new Vector3 (temporaryMan.transform.localScale.x * choices[myRandomIndex], temporaryMan.transform.localScale.y,0);
                       allEnemies.Add(temporaryMan);
                        temporaryMan.GetComponent<MechPhys>().stand();
                        Destroy(allEnemiesDeath[enemy]);
                   }
                   else if (allEnemiesDeath[enemy].GetComponent<YogiFollow>() != null)
                   {
                       myRandomIndex = Random.Range( 0, choices.Count);
                        if (patrol[enemy])
                       {
                           temporaryMan = Instantiate(yogiP, distances[enemy], yogiP.transform.rotation);
                       }
                        else
                       {
                          temporaryMan = Instantiate(yogi, distances[enemy], yogi.transform.rotation);
                       }
                      
                       temporaryMan.transform.localScale = new Vector3 (allEnemiesDeath[enemy].transform.localScale.x, temporaryMan.transform.localScale.y,0);
                       allEnemies.Add(temporaryMan);
                       Destroy(allEnemiesDeath[enemy]);
                   }
                   else if (allEnemiesDeath[enemy].GetComponent<TurretBehave>() != null)
                   {
                    
                       temporaryMan = Instantiate(turret, distances[enemy], turret.transform.rotation);
                      
                      
                       temporaryMan.transform.localScale = new Vector3 (allEnemiesDeath[enemy].transform.localScale.x, temporaryMan.transform.localScale.y,0);
                       allEnemies.Add(temporaryMan);
                       Destroy(allEnemiesDeath[enemy]);
                   }
                  else if (allEnemiesDeath[enemy].GetComponent<droidBehave>() != null)
                   {
                    
                       allEnemiesDeath[enemy].GetComponent<droidBehave>().triggered = false;
                       temporaryMan = allEnemiesDeath[enemy];
                       temporaryMan.transform.position = distances[enemy];
                       
                       allEnemies.Add(temporaryMan);
                   }
                   
                     
                     
                  }
                  if (allEnemiesDeath[enemy] == null)
                     allEnemies.Add(null);
               }
            }
           
        }
        else if((float)GameObject.FindGameObjectsWithTag("EnemyEasy").Length/enemyNumber != 0)
        {
             List<int> deadEnemies = new List<int>();

             
             if (allEnemiesDeath.Count != 0)
                {
                     for(var enemy = 0; enemy < allEnemiesDeath.Count; enemy ++)
                           { 
                              if (allEnemiesDeath[enemy] != null)
                              { deadEnemies.Add(enemy);
                              ;}
                           }
                }
                
             int number = Random.Range(0, allEnemiesDeath.Count);
             int type;
           
          
             for (int i = 0; ((float)(deadEnemies.Count)/(float)enemyNumber) < 0.5; i++)
              {
                 
                 do {
              
                   number = Random.Range(0, allEnemiesDeath.Count);
      
                    } while (deadEnemies.Contains(number));
                   
                   deadEnemies.Add(number);
              }
             for(var enemy = 0; enemy < allEnemiesDeath.Count; enemy ++)
               {
                  if (allEnemiesDeath[enemy] != null)
                  { 
                    if (allEnemiesDeath[enemy].GetComponent<FollowBehave>() != null)
                    {
                     myRandomIndex = Random.Range( 0, choices.Count);
                           if (patrol[enemy])
                       {
                            temporaryMan = Instantiate(mechnickEasyP, distances[enemy], mechnickEasy.transform.rotation);
                       }
                       else
                       {
                            temporaryMan = Instantiate(mechnickEasy, distances[enemy], mechnickEasy.transform.rotation);
                       }
                     temporaryMan.transform.localScale = new Vector3 (temporaryMan.transform.localScale.x * choices[myRandomIndex], temporaryMan.transform.localScale.y,0);
                     allEnemies.Add(temporaryMan);
                     temporaryMan.GetComponent<MechPhys>().stand();
                           Destroy(allEnemiesDeath[enemy]);
                     }
                    else if (allEnemiesDeath[enemy].GetComponent<EasyGunnerFollow>() != null)
                    {
                       myRandomIndex = Random.Range( 0, choices.Count);
                        if (patrol[enemy])
                       {
                                 temporaryMan = Instantiate(shooteRP, distances[enemy], shooteRP.transform.rotation);
                       }
                       else
                       {
                                temporaryMan = Instantiate(shooteR, distances[enemy], shooteR.transform.rotation);
                       }
                 
                       temporaryMan.transform.localScale = new Vector3 (temporaryMan.transform.localScale.x * choices[myRandomIndex], temporaryMan.transform.localScale.y,0);
                       allEnemies.Add(temporaryMan);
                        temporaryMan.GetComponent<MechPhys>().stand();
                              Destroy(allEnemiesDeath[enemy]);
                    }
                  else if (allEnemiesDeath[enemy].GetComponent<FollowBehaveSwordman>() != null)
                   {
                       myRandomIndex = Random.Range( 0, choices.Count);
                       if (patrol[enemy])
                       {
                           temporaryMan = Instantiate(swordManP, distances[enemy], swordManP.transform.rotation);
                       }
                        else
                       {
                          temporaryMan = Instantiate(swordMan, distances[enemy], swordMan.transform.rotation);
                       }
                       temporaryMan.transform.localScale = new Vector3 (temporaryMan.transform.localScale.x * choices[myRandomIndex], temporaryMan.transform.localScale.y,0);
                       allEnemies.Add(temporaryMan);
                        temporaryMan.GetComponent<MechPhys>().stand();
                              Destroy(allEnemiesDeath[enemy]);
                   }
                    else if (allEnemiesDeath[enemy].GetComponent<YogiFollow>() != null)
                   {
                       myRandomIndex = Random.Range( 0, choices.Count);
                        if (patrol[enemy])
                       {
                           temporaryMan = Instantiate(yogiP, distances[enemy], yogiP.transform.rotation);
                       }
                        else
                       {
                          temporaryMan = Instantiate(yogi, distances[enemy], yogi.transform.rotation);
                       }
                      
                       temporaryMan.transform.localScale = new Vector3 (allEnemiesDeath[enemy].transform.localScale.x, temporaryMan.transform.localScale.y,0);
                       allEnemies.Add(temporaryMan);
                             Destroy(allEnemiesDeath[enemy]);
                   }
                   else if (allEnemiesDeath[enemy].GetComponent<TurretBehave>() != null)
                   {
                    
                       temporaryMan = Instantiate(turret, distances[enemy], turret.transform.rotation);
                      
                      
                       temporaryMan.transform.localScale = new Vector3 (allEnemiesDeath[enemy].transform.localScale.x, temporaryMan.transform.localScale.y,0);
                       allEnemies.Add(temporaryMan);
                             Destroy(allEnemiesDeath[enemy]);
                   }
                      else if (allEnemiesDeath[enemy].GetComponent<droidBehave>() != null)
                   {
                    
                         allEnemiesDeath[enemy].GetComponent<droidBehave>().triggered = false;
                       temporaryMan = allEnemiesDeath[enemy];
                       temporaryMan.transform.position = distances[enemy];
                       
                       allEnemies.Add(temporaryMan);
                   }
                
                    
                  }
                  if (allEnemiesDeath[enemy] == null)
                  {
                     if (deadEnemies.Contains(enemy))
                     {
                         ressurected = false;
                         while (!ressurected)
                         {
                             type = Random.Range(0, 4);
                             if(mechnickEasy != null && type == 0 )
                               {
                                myRandomIndex = Random.Range( 0, choices.Count);
                                  if (patrol[enemy])
                                   {
                                    temporaryMan = Instantiate(mechnickEasyP, distances[enemy], mechnickEasy.transform.rotation);
                                   }
                                 else
                                   {
                                   temporaryMan = Instantiate(mechnickEasy, distances[enemy], mechnickEasy.transform.rotation);
                                   }
                                temporaryMan.transform.localScale = new Vector3 (temporaryMan.transform.localScale.x * choices[myRandomIndex], temporaryMan.transform.localScale.y,0);
                                allEnemies.Add(temporaryMan);
                                temporaryMan.GetComponent<MechPhys>().stand();
                                ressurected = true;
                               }
                            else if (shooteR != null && type == 1 )
                               {
                               myRandomIndex = Random.Range( 0, choices.Count);
                                    if (patrol[enemy])
                                   {
                                    temporaryMan = Instantiate(shooteRP, distances[enemy], shooteRP.transform.rotation);
                                   }
                                 else
                                   {
                                temporaryMan = Instantiate(shooteR, distances[enemy], shooteR.transform.rotation);
                                   }
                             
                               temporaryMan.transform.localScale = new Vector3 (temporaryMan.transform.localScale.x * choices[myRandomIndex], temporaryMan.transform.localScale.y,0);
                               allEnemies.Add(temporaryMan);
                                temporaryMan.GetComponent<MechPhys>().stand();
                               ressurected = true;
                               }
                           else if (swordMan != null && type == 2)
                               {
                               myRandomIndex = Random.Range( 0, choices.Count);
                              if (patrol[enemy])
                                 {
                                    temporaryMan = Instantiate(swordManP, distances[enemy], swordMan.transform.rotation);
                                 }
                              else
                                 {
                                    temporaryMan = Instantiate(swordMan, distances[enemy], swordMan.transform.rotation);
                                 }
                               temporaryMan.transform.localScale = new Vector3 (temporaryMan.transform.localScale.x * choices[myRandomIndex], temporaryMan.transform.localScale.y,0);
                               allEnemies.Add(temporaryMan);
                                temporaryMan.GetComponent<MechPhys>().stand();
                               ressurected = true;
                               }
                               
                           else if (droidBehave != null && type == 3)
                               {
                               myRandomIndex = Random.Range( 0, choices.Count);
                              if (patrol[enemy])
                                 {
                                    temporaryMan = Instantiate(droidBehaveP, distances[enemy], droidBehave.transform.rotation);
                                 }
                              else
                                 {
                                    temporaryMan = Instantiate(droidBehave, distances[enemy], droidBehave.transform.rotation);
                                 }
                               allEnemies.Add(temporaryMan);
                               ressurected = true;
                               }
                               
                         }
                     }
                     else 
                     {
                         allEnemies.Add(null);
                     }
                  }
               }
              
              
            
        }
        break;
        //no revive
          case 1:
               allEnemiesDeath = new List<GameObject>();
               allEnemiesDeath = allEnemies;
               allEnemies = new List<GameObject>();
       
    
      
         if (allEnemiesDeath.Count != 0)
            {
            for(var enemy = 0; enemy < allEnemiesDeath.Count; enemy ++)
                {
                  if (allEnemiesDeath[enemy] != null)
                  {
                   
                    if(allEnemiesDeath[enemy].GetComponent<FollowBehave>() != null)
                   {
                       myRandomIndex = Random.Range( 0, choices.Count);
                         if (patrol[enemy])
                       {
                            temporaryMan = Instantiate(mechnickEasyP, distances[enemy], mechnickEasyP.transform.rotation);
                       }
                       else
                       {
                            temporaryMan = Instantiate(mechnickEasy, distances[enemy], mechnickEasy.transform.rotation);
                       }
                       temporaryMan.transform.localScale = new Vector3 (temporaryMan.transform.localScale.x * choices[myRandomIndex], temporaryMan.transform.localScale.y,0);
                       allEnemies.Add(temporaryMan);
                       temporaryMan.GetComponent<MechPhys>().stand();
                   }
                   else if (allEnemiesDeath[enemy].GetComponent<EasyGunnerFollow>() != null)
                   {
                       myRandomIndex = Random.Range( 0, choices.Count);
                         if (patrol[enemy])
                       {
                            temporaryMan = Instantiate(shooteRP, distances[enemy], allEnemiesDeath[enemy].transform.rotation);
                       }
                       else
                       {
                            temporaryMan = Instantiate(shooteR, distances[enemy], allEnemiesDeath[enemy].transform.rotation);
                       }
                       
                       temporaryMan.transform.localScale = new Vector3 (temporaryMan.transform.localScale.x * choices[myRandomIndex], temporaryMan.transform.localScale.y,0);
                       allEnemies.Add(temporaryMan);
                        temporaryMan.GetComponent<MechPhys>().stand();
                   }
                    else if (allEnemiesDeath[enemy].GetComponent<FollowBehaveSwordman>() != null)
                   {
                       myRandomIndex = Random.Range( 0, choices.Count);
                        if (patrol[enemy])
                       {
                           temporaryMan = Instantiate(swordManP, distances[enemy], swordManP.transform.rotation);
                       }
                        else
                       {
                          temporaryMan = Instantiate(swordMan, distances[enemy], swordMan.transform.rotation);
                       }
                      
                       temporaryMan.transform.localScale = new Vector3 (temporaryMan.transform.localScale.x * choices[myRandomIndex], temporaryMan.transform.localScale.y,0);
                       allEnemies.Add(temporaryMan);
                        temporaryMan.GetComponent<MechPhys>().stand();
                   }
                    else if (allEnemiesDeath[enemy].GetComponent<YogiFollow>() != null)
                   {
                       myRandomIndex = Random.Range( 0, choices.Count);
                        if (patrol[enemy])
                       {
                           temporaryMan = Instantiate(yogiP, distances[enemy], yogiP.transform.rotation);
                       }
                        else
                       {
                          temporaryMan = Instantiate(yogi, distances[enemy], yogi.transform.rotation);
                       }
                      
                       temporaryMan.transform.localScale = new Vector3 (temporaryMan.transform.localScale.x * choices[myRandomIndex], temporaryMan.transform.localScale.y,0);
                       allEnemies.Add(temporaryMan);
                   }
                     Destroy(allEnemiesDeath[enemy]);
                     
                  }
                  if (allEnemiesDeath[enemy] == null)
                     allEnemies.Add(null);
               }
            }
              break;
              //training
              case 2:
                 allEnemiesDeath = new List<GameObject>();
                 allEnemiesDeath = allEnemies;
                 allEnemies = new List<GameObject>();
                 
              for(var enemy = 0; enemy < allEnemiesDeath.Count; enemy ++)
               {
                  if (allEnemiesDeath[enemy] != null)
                  { 
                    if (allEnemiesDeath[enemy].GetComponent<FollowBehave>() != null)
                    {
                     myRandomIndex = Random.Range( 0, choices.Count);
                           if (patrol[enemy])
                       {
                            temporaryMan = Instantiate(mechnickEasyP, distances[enemy], mechnickEasy.transform.rotation);
                       }
                       else
                       {
                            temporaryMan = Instantiate(mechnickEasy, distances[enemy], mechnickEasy.transform.rotation);
                       }
                  
                     allEnemies.Add(temporaryMan);
                     temporaryMan.GetComponent<MechPhys>().stand();
                     }
                    else if (allEnemiesDeath[enemy].GetComponent<EasyGunnerFollow>() != null)
                    {
                       myRandomIndex = Random.Range( 0, choices.Count);
                             if (patrol[enemy])
                       {
                             temporaryMan = Instantiate(shooteRP, distances[enemy], shooteRP.transform.rotation);
                       }
                       else
                       {
                         temporaryMan = Instantiate(shooteR, distances[enemy], shooteR.transform.rotation);
                       }
                      
                         temporaryMan.transform.localScale = new Vector3 (temporaryMan.transform.localScale.x * (-1), temporaryMan.transform.localScale.y,0);
                       allEnemies.Add(temporaryMan);
                        temporaryMan.GetComponent<MechPhys>().stand();
                       
                    }
                  else if (allEnemiesDeath[enemy].GetComponent<FollowBehaveSwordman>() != null)
                   {
                       myRandomIndex = Random.Range( 0, choices.Count);
                       if (patrol[enemy])
                       {
                           temporaryMan = Instantiate(swordManP, distances[enemy], swordManP.transform.rotation);
                       }
                        else
                       {
                          temporaryMan = Instantiate(swordMan, distances[enemy], swordMan.transform.rotation);
                       }
                
                       allEnemies.Add(temporaryMan);
                        temporaryMan.GetComponent<MechPhys>().stand();
                   }
                      Destroy(allEnemiesDeath[enemy]);
                    
                  }
                  if (allEnemiesDeath[enemy] == null && allEnemiesDeath.Count >2)
                         {
                 
                    
                 
                            temporaryMan = Instantiate(mechnickEasy, distances[enemy], mechnickEasy.transform.rotation);
                          
                            allEnemies.Add(temporaryMan);
                            temporaryMan.GetComponent<MechPhys>().stand();
                     
                         }
                         else
                         {
                             if (allEnemiesDeath[enemy] == null && enemy == 0)
                             {
                            temporaryMan = Instantiate(shooteR, distances[0], mechnickEasy.transform.rotation);
                          
                            allEnemies.Add(temporaryMan);
                            temporaryMan.transform.localScale = new Vector3 (temporaryMan.transform.localScale.x * (-1), temporaryMan.transform.localScale.y,0);
                             }
                             else if (allEnemiesDeath[enemy] == null)
                             {
                             temporaryMan = Instantiate(mechnickEasy, distances[1], mechnickEasy.transform.rotation);
                          
                            allEnemies.Add(temporaryMan);
                            temporaryMan.GetComponent<MechPhys>().stand();
                             }
                            
                           
                   
                         }
                          
                         
                     
      
             
                  
               }
               
              break;
              
             case 3:
             
                 allEnemiesDeath = new List<GameObject>();
                 allEnemiesDeath = allEnemies;
                 allEnemies = new List<GameObject>();
       
             break;
          }
          
          if(yogi !=null)
          {
            
            yield return new WaitForSeconds(1.5f);

         GameObject[] yogiD = GameObject.FindGameObjectsWithTag("deviceYogi");
          if (yogiD !=null)
          {
                foreach(var ps in yogiD)
                  {
                     
                      Destroy(ps);
  
                  }
          }
          }
       SaveSystem.SavePlayer(SceneManager.GetActiveScene().buildIndex);
            //capsuleRevive
       if (PlayerPrefs.GetInt("Underground") == 0)
        {
        Destroy(GameObject.FindWithTag("Capsule"));
        yield return new WaitForSeconds(0.5f);
        BS.GetComponent<Image>().color = new Color(BS.GetComponent<Image>().color.r, BS.GetComponent<Image>().color.g, BS.GetComponent<Image>().color.b, 0f);
        BS.SetActive(false);
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        Destroy(GameObject.FindWithTag("Capsule"));
        cameraFollow.target =  Instantiate(capsule, position , transform.rotation).GetComponent<CapsulePhys>();
        cameraFollow.focusAreaSize = new Vector2 (2, 2);
        cameraFollow.lookAheadDstX = 1;
        cameraFollow.verticalOffset = -1;
        }
        //revive without capsule;
        if (PlayerPrefs.GetInt("Underground") == 1)
        {
     
        BS.GetComponent<Image>().color = new Color(BS.GetComponent<Image>().color.r, BS.GetComponent<Image>().color.g, BS.GetComponent<Image>().color.b, 0f);
        BS.SetActive(false);
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        playerDum = null;
        playerDum =  Instantiate(player, position , transform.rotation);
        if (cameraFollow != null)
        {
        cameraFollow.target = playerDum.GetComponent<Controller2D>();
        }
        yield return new WaitForSeconds(0.5f);
        CameraShake.Shake(0.5f, 1f);
        yield return new WaitForSeconds(0.5f);
        GameManager.GM.scriptOn = true;
        playerDum.GetComponent<PlayerInput>().horizontal = 1;
        yield return new WaitForSeconds(0.5f);
        GameManager.GM.scriptOn = false;
        yield return new WaitForSeconds(0.3f);
        }
        //instant revive for training levels
        if (PlayerPrefs.GetInt("Underground") == 2)
        {
        yield return new WaitForSeconds(0.8f);
        playerDum = null;
        playerDum =  Instantiate(player, position , transform.rotation);
        GameManager.GM.scriptOn = true;
        playerDum.GetComponent<PlayerInput>().horizontal = 1;
        yield return new WaitForSeconds(0.5f);
        GameManager.GM.scriptOn = false;
        yield return new WaitForSeconds(0.3f);
        }
        //withoutShake
        if (PlayerPrefs.GetInt("Underground") == 3)
        {
     
        BS.GetComponent<Image>().color = new Color(BS.GetComponent<Image>().color.r, BS.GetComponent<Image>().color.g, BS.GetComponent<Image>().color.b, 0f);
        BS.SetActive(false);
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        playerDum = null;
        playerDum =  Instantiate(player, position , transform.rotation);
        if (cameraFollow != null)
        {
        cameraFollow.target = playerDum.GetComponent<Controller2D>();
        }
        yield return new WaitForSeconds(1);
        GameManager.GM.scriptOn = true;
        playerDum.GetComponent<PlayerInput>().horizontal = 1;
        yield return new WaitForSeconds(0.5f);
        GameManager.GM.scriptOn = false;
        yield return new WaitForSeconds(0.3f);
        }
        
        EnemyCounters.EC.enemyNumber = 0;
        foreach(GameObject enemy in allEnemies)
        {
            if (enemy != null)
            {
                EnemyCounters.EC.enemyNumber +=1;
            }
        }
       
    
     }
     else if (GameManager.GM.lifeNumber == -1)
     {
            if (GameManager.GM.gameMode == 0)
            {
                GameManager.GM.load = false;
                switch(GameManager.GM.levelRevive)
                {
                    case 0:
                    File.Delete(Application.dataPath + "/saveData.lil");
                    GameManager.GM.lifeNumber = 100;
                    GameManager.GM.numberofPills = 0;
                    GameManager.GM.fishFeed = 0;
                    GameManager.GM.strangeTalking = 0;
                    GameManager.GM.difficulty = 0;
                    GameManager.GM.releaseScientist = 0;
                    GameManager.GM.kidNarkotik = 0;
                    GameManager.GM.erdonit = 0;
                    GameManager.GM.knowTheTruth = 0;
                    GameManager.GM.agree = 0;
                    GameManager.GM.juliaAgree = 0;
                    GameManager.GM.goSave =  0;
                    GameManager.GM.gameMode =  0;
                    GameManager.GM.levelRevive = 0;
                    GameManager.GM.jokes = 0;
                    GameManager.GM.canSkip = true;
                    StartCoroutine(reloadLevel1());
                    break;
                    case 2:
                    SaveSystem.SavePlayer(8);
                    levelReviveN = 8;
                    StartCoroutine(reload());
                    break;
                    case 3:
                    SaveSystem.SavePlayer(16);
                    levelReviveN = 16;
                    StartCoroutine(reload());
                    break;
                    case 4:
                    SaveSystem.SavePlayer(28);
                    levelReviveN = 28;
                    StartCoroutine(reload());
                    break;
                    case 5:
                    SaveSystem.SavePlayer(34);
                    levelReviveN = 34;
                    StartCoroutine(reload());
                    break;
                    case 6:
                    SaveSystem.SavePlayer(44);
                    levelReviveN = 44;
                    StartCoroutine(reload());
                    break;
                    case 7:
                    SaveSystem.SavePlayer(55);
                    levelReviveN = 55;
                    StartCoroutine(reload());
                    break;
                    case 8:
                    SaveSystem.SavePlayer(63);
                    levelReviveN = 63;
                    StartCoroutine(reload());
                    break;
                }
  
            }   
            else if (GameManager.GM.gameMode == 1)
            {
                File.Delete(Application.dataPath + "/saveData.lil");
                GameManager.GM.lifeNumber = 100;
                GameManager.GM.numberofPills = 0;
                GameManager.GM.fishFeed = 0;
                GameManager.GM.strangeTalking = 0;
                GameManager.GM.difficulty = 0;
                GameManager.GM.releaseScientist = 0;
                GameManager.GM.kidNarkotik = 0;
                GameManager.GM.erdonit = 0;
                GameManager.GM.knowTheTruth = 0;
                GameManager.GM.agree = 0;
                GameManager.GM.juliaAgree = 0;
                GameManager.GM.goSave =  0;
                GameManager.GM.gameMode =  0;
                GameManager.GM.levelRevive = 0;
                GameManager.GM.jokes = 0;
                GameManager.GM.canSkip = true;
                StartCoroutine(Death());
                
            }                
     }
          
    }
    
       IEnumerator Death()
    {  
         MusicManager.MM.Stop();
       yield return new WaitForSeconds(1f); 
       BS.SetActive(true);
        yield return new WaitForSeconds(1.8f); 
       StartCoroutine( BS.transform.GetChild(0).gameObject.GetComponent<TextAppear>().TypeText (ImportText.allPhrases["checkStatus"][PlayerPrefs.GetString("language")]));
       yield return new WaitForSeconds(4f); 
       StartCoroutine( BS.transform.GetChild(0).gameObject.GetComponent<TextAppear>().TypeText (ImportText.allPhrases["youaredead"][PlayerPrefs.GetString("language")]));
        yield return new WaitForSeconds(4f); 
       SceneManager.LoadScene(0);
    }
    
      IEnumerator reload()
    {  
         MusicManager.MM.Stop();
       yield return new WaitForSeconds(1f); 
       BS.SetActive(true);
        yield return new WaitForSeconds(1.8f); 
       StartCoroutine( BS.transform.GetChild(0).gameObject.GetComponent<TextAppear>().TypeText (ImportText.allPhrases["checkStatus"][PlayerPrefs.GetString("language")]));
       yield return new WaitForSeconds(4f); 
       StartCoroutine( BS.transform.GetChild(0).gameObject.GetComponent<TextAppear>().TypeText (ImportText.allPhrases["reload"][PlayerPrefs.GetString("language")]));
        yield return new WaitForSeconds(4f); 
        StartCoroutine( BS.transform.GetChild(0).gameObject.GetComponent<TextAppear>().TypeText (ImportText.allPhrases["returnBack"][PlayerPrefs.GetString("language")]));
          yield return new WaitForSeconds(4f);
       SceneManager.LoadScene(levelReviveN);
    }
    
    IEnumerator reloadLevel1()
    {  
         MusicManager.MM.Stop();
       yield return new WaitForSeconds(1f); 
       BS.SetActive(true);
        yield return new WaitForSeconds(1.8f); 
       StartCoroutine( BS.transform.GetChild(0).gameObject.GetComponent<TextAppear>().TypeText (ImportText.allPhrases["checkStatus"][PlayerPrefs.GetString("language")]));
       yield return new WaitForSeconds(4f); 
       StartCoroutine( BS.transform.GetChild(0).gameObject.GetComponent<TextAppear>().TypeText (ImportText.allPhrases["reload"][PlayerPrefs.GetString("language")]));
        yield return new WaitForSeconds(4f); 
        StartCoroutine( BS.transform.GetChild(0).gameObject.GetComponent<TextAppear>().TypeText (ImportText.allPhrases["returnBackLevel1"][PlayerPrefs.GetString("language")]));
          yield return new WaitForSeconds(4f);
       SceneManager.LoadScene(0);
    }
    
      void DoCheckEnemyPositions() {
         
        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("EnemyEasy"))
        { allEnemies.Add(enemy);}
       
        enemyNumber = allEnemies.Count;
        distances = new List<Vector3>();
        patrol = new List<bool>();
        if (allEnemies.Count != 0)
        {
          foreach(GameObject enemy in allEnemies)
          {
            distances.Add(enemy.transform.position);
            patrol.Add(enemy.GetComponent<EasyEnemy>().PatrolType);
          }
        }
       /* if (allEnemies.Length != 0){
         for(var enemy = 0; enemy < allEnemies.Length; enemy ++) {
             if (allAllies[ally] == null && distances[ally] <10){
             triggered = true;
             }
      
        }
        } */
   }
}
