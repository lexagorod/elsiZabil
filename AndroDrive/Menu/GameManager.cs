using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Steamworks;


public class GameManager : MonoBehaviour
{
     
    public static GameManager GM;
    
    
    public KeyCode jump {get; set;}
    public KeyCode down {get; set;}
    public KeyCode left {get; set;}
    public KeyCode right {get; set;}
    public KeyCode attack {get; set;}
    public KeyCode action  {get; set;}
    public KeyCode dodge  {get; set;}
    public KeyCode ult  {get; set;}
    public KeyCode accept  {get; set;}
    public KeyCode attackJC  {get; set;}
    public KeyCode jumpJC  {get; set;}
    public KeyCode actionJC  {get; set;}
    public KeyCode dodgeJC  {get; set;}
    public KeyCode ultJC  {get; set;}
    public KeyCode escape  {get; set;}
    public KeyCode escapeJC  {get; set;}
    
    //prevent from pressing enter when don't need see menuscriptmine
    public bool inputOn;
    public bool scriptOn;
    public int width;
    public int height;
    public int lifeNumber;
    public int intellectLevel;
    public int numberofPills;
    public int fishFeed;
    public int strangeTalking;
    public int returnScene;
    public int difficulty;
    //jokesNumberYouSay
    public int jokes;
    public int juliaAgree;
    //level Revive for casual mode
    public int levelRevive;
    public int gameMode;
    //agree to work with Homines
    public int captainAgreeAnswer;
    //save Julia
    public int goSave;
    //know about ustanovki
    public int knowTheTruth;
      //agree to cooperate with govenment
    public int agree;
    public int releaseScientist;
    public int kidNarkotik;
   //doctordialogue about erdonit
    public int erdonit;
    public bool cameraBroken;
    public int robotTalkers;
    public float textSpeed;
    //check if level loaded 
    public bool load;
    public bool textRunning;
    // next level trigger for example 1-4
    public bool nextLevelMarker;
    //trigger for different events
    public bool eventHappen;
    public bool eventHappenSecond;
    //if panel visibility don't need use this
    public bool alternativeInput;
    public bool switchTalker;
    public bool throwBomb;
    public bool menuActive;
    public bool textStop;
    // if black screenactive
    public bool blackTextScreen;
    //skip long dialogues
    public bool canSkip;
    public bool skipFilled;
    //kostil shtobi text ne skipalsi pachkou
    public bool readyForSkip;
    public bool cursorAlwaysVisible;

   
  
 
    void Awake(){
        
        if(GM == null){
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if (GM != this){
            Destroy(gameObject);
        }
        /*
        try 
         {
           SteamClient.Init(1234850);
         }
         catch ( System.Exception e )
          {
            // Couldn't init for some reason (steam is closed etc)
          }
          */
          
        robotTalkers = 0;
        load = false;
        textRunning = false;
        inputOn = true;
        alternativeInput = false;
        intellectLevel = 3;
        nextLevelMarker = false;
        eventHappen = false;
        eventHappenSecond = false;
        switchTalker = false;
        cameraBroken = false;
        menuActive = false;
        textStop = true;
        blackTextScreen = false;
        canSkip = false;
        readyForSkip = true;
        numberofPills = 0;
        fishFeed = 0;
        strangeTalking = 0;
        releaseScientist = 0;
        returnScene = 7;
        difficulty = 0;
        kidNarkotik = 1;
        throwBomb = true;
        erdonit = 0;
        knowTheTruth = 0;
        agree = 0;
        juliaAgree = 0;
        goSave = 0;
        captainAgreeAnswer = 0;
        gameMode = 0;
        textSpeed = PlayerPrefs.GetFloat("textSpeed",0.02f);
        levelRevive = 0;
        jokes = 0;
        cursorAlwaysVisible = false;
     
        
        jump = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpKey", "W"));
        down = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("DownKey", "S"));
        left = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftKey", "A"));
        right = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightKey", "D"));
        attack = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("AttackKey", "Mouse0"));
        action = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ActionKey", "Mouse1"));
        dodge = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("DodgeKey", "Space"));
        ult = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("UltKey", "E"));
        accept = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("AcceptKey", "F"));
        escape = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("EscapeKey", "Escape"));
        attackJC = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("AttackJC", "JoystickButton7"));
        jumpJC = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpJC", "JoystickButton2"));
        actionJC = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ActionJC", "JoystickButton6"));
        dodgeJC = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("DodgeJC", "JoystickButton3"));
        ultJC = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("UltJC", "JoystickButton4"));
        escapeJC = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("EscapeKeyJC", "JoystickButton8"));
        scriptOn = false;
        
         string[] args = System.Environment.GetCommandLineArgs ();
         for (int i = 0; i < args.Length; i++) {
         if (args [i] == "-visibleCursor") {
                 cursorAlwaysVisible = true;
             }
 }
    
        
    }
    
    public void SetWidth(int newWidth)
    {
        width = newWidth;
    }
    
    public void SetHeight(int newHeight)
    {
        height = newHeight;
    }
    
    public void SetRes(bool change)
    {
        
        int sWidth = Screen.currentResolution.width;
        int sHeight = 0;
        if (sWidth < 1152)
        {
            sWidth = 1024;
            sHeight = 576;
        }
        else if (sWidth >=1152 && sWidth <1280)
        {
            sWidth = 1152;
            sHeight = 648;
        }
            else if (sWidth >=1280 && sWidth <1366)
        {
            sWidth = 1280;
            sHeight = 720;
        }
            else if (sWidth >=1366 && sWidth <1600)
        {
            sWidth = 1366;
            sHeight = 768;
        }
           else if (sWidth >=1600 && sWidth <1920)
        {
            sWidth = 1600;
            sHeight = 900;
        }
           else if (sWidth >=1920 && sWidth <2560)
        {
            sWidth = 1920;
            sHeight = 1080;
        }
            else if (sWidth >=2560 && sWidth <3840)
        {
            sWidth = 2560;
            sHeight = 1440;
        }
          else if (sWidth >=3840)
        {
            sWidth = 3840;
            sHeight = 2160;
        }
        
       if ( Screen.fullScreen)
                {
                    if (!change)
                    {
                     Screen.SetResolution(sWidth, sHeight, true);
                    }
                    else
                    {
                        Screen.SetResolution( (int)(sWidth/1.35f), (int) (sHeight/1.35f), false);
                    }
                  //  SettingPanel.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["window"][PlayerPrefs.GetString("language")]; 
                  
                }
                else
                {
                  if (!change)
                    {
                     Screen.SetResolution( (int)(sWidth/1.35f), (int) (sHeight/1.35f), false);
                    }
                    else
                    {
                       Screen.SetResolution(sWidth, sHeight, true);
                    }
                  //   SettingPanel.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["fullscreen"][PlayerPrefs.GetString("language")]; 
                }
    }
    void Start()
    {
        SetRes(false);
    }
    
    public void achievement(string achName)
    {
        
       //  var ach = new Steamworks.Data.Achievement( achName );
       //  ach.Trigger();
    }

    // Update is called once per frame
    void Update()
    {
        //  Steamworks.SteamClient.RunCallbacks();
          if (cursorAlwaysVisible)
          {
                Cursor.lockState = CursorLockMode.None;         
                Cursor.visible = true; 
          }
    }
    
     void OnDisable()
    {
      //  Steamworks.SteamClient.Shutdown();
    }
   
}
