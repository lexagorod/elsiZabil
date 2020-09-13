using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuScriptMineMainMenu : MonoBehaviour
{
    public Transform menuPanel;
    Event keyEvent;
    TextMeshProUGUI buttonText;
    KeyCode newKey;
    Button dummy;
    GameObject ButtonJump;
    GameObject ButtonAttack;
    GameObject ButtonDown;
    GameObject ButtonLeft;
    GameObject ButtonRight;
    GameObject ButtonDash;
    GameObject ButtonUlti;
    GameObject ButtonAccept;
    GameObject ButtonEscape;
    GameObject ButtonAction;
    
    GameObject ButtonJumpAcceptJC;
    GameObject ButtonAttackJC;
    GameObject ButtonDashJC;
    GameObject ButtonUltiJC;
    GameObject ButtonEscapeJC;
    GameObject ButtonActionJC;
    
    GameObject SoundPanel;
    GameObject SettingPanel;
    GameObject ControlPanel;
    GameObject PCPanel;
    GameObject JoystickPanel;
    Image btnC;
    Slider slider, sliderMusic;
    int keyPressed = 0;
    bool waitingForKey;
    bool cantClickGui;
    bool setSelected = true;
    GameObject player;
    bool canChangeVolume;
    bool cursorState;
    bool first;
    // Start is called before the first frame update
    void Start()
    {

       // menuPanel = transform.Find("ControlPanel");
       canChangeVolume = true;
                //KEYBOARD
                PCPanel =  menuPanel.GetChild(0).gameObject;
                
                ButtonJump = PCPanel.transform.GetChild(0).gameObject;
                ButtonJump.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.jump.ToString();
             
                ButtonDown = PCPanel.transform.GetChild(1).gameObject;
                ButtonDown.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.down.ToString();
                
                ButtonLeft = PCPanel.transform.GetChild(2).gameObject;
                ButtonLeft.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.left.ToString();
                
                ButtonRight = PCPanel.transform.GetChild(3).gameObject;
                ButtonRight.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.right.ToString();
                
                ButtonDash = PCPanel.transform.GetChild(4).gameObject;
                ButtonDash.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.dodge.ToString();
                
                ButtonUlti = PCPanel.transform.GetChild(5).gameObject;
                ButtonUlti.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.ult.ToString();
                
                ButtonAccept = PCPanel.transform.GetChild(6).gameObject;
                ButtonAccept.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.accept.ToString();
                
                ButtonEscape = PCPanel.transform.GetChild(7).gameObject;
                ButtonEscape.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.escape.ToString();
                
                ButtonAttack = PCPanel.transform.GetChild(8).gameObject;
                ButtonAttack.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["LeftMouse"][PlayerPrefs.GetString("language")]; 
                
                ButtonAction = PCPanel.transform.GetChild(9).gameObject;
                ButtonAction.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["RightMouse"][PlayerPrefs.GetString("language")]; 
                
                PCPanel.transform.GetChild(10).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["goback"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(11).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["jump"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["down"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(13).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["left"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(14).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["right"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(15).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["dash"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(16).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["ulti"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(17).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["accept"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(18).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["escape"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(19).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["attack"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(20).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["action"][PlayerPrefs.GetString("language")]; 
                
                //GAMEPAD
                JoystickPanel = menuPanel.GetChild(4).gameObject;
                
                ButtonJumpAcceptJC = JoystickPanel.transform.GetChild(0).gameObject;
                ButtonJumpAcceptJC.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.jumpJC.ToString();
                
                ButtonDashJC = JoystickPanel.transform.GetChild(1).gameObject;
                ButtonDashJC.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.dodgeJC.ToString();
                
                ButtonUltiJC = JoystickPanel.transform.GetChild(2).gameObject;
                ButtonUltiJC.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.ultJC.ToString();
                
                ButtonEscapeJC = JoystickPanel.transform.GetChild(3).gameObject;
                ButtonEscapeJC.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.escapeJC.ToString();
                
                ButtonAttackJC = JoystickPanel.transform.GetChild(4).gameObject;
                ButtonAttackJC.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.attackJC.ToString();
                
                ButtonActionJC = JoystickPanel.transform.GetChild(5).gameObject;
                ButtonActionJC.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.actionJC.ToString();
                
                JoystickPanel.transform.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["goback"][PlayerPrefs.GetString("language")]; 
                JoystickPanel.transform.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["jumpAccept"][PlayerPrefs.GetString("language")]; 
                JoystickPanel.transform.GetChild(8).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["dash"][PlayerPrefs.GetString("language")]; 
                JoystickPanel.transform.GetChild(9).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["ulti"][PlayerPrefs.GetString("language")]; 
                JoystickPanel.transform.GetChild(10).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["escape"][PlayerPrefs.GetString("language")]; 
                JoystickPanel.transform.GetChild(11).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["attack"][PlayerPrefs.GetString("language")]; 
                JoystickPanel.transform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["action"][PlayerPrefs.GetString("language")]; 
                
                //otherPanels
                SoundPanel = menuPanel.GetChild(1).gameObject;
                SettingPanel = menuPanel.GetChild(2).gameObject;
                ControlPanel = menuPanel.GetChild(3).gameObject;
                SettingPanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["audio"][PlayerPrefs.GetString("language")]; 
                SettingPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["controls"][PlayerPrefs.GetString("language")]; 
                if ( Screen.fullScreen)
                {
                     SettingPanel.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["window"][PlayerPrefs.GetString("language")]; 
                }
                else
                {
                    SettingPanel.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["fullscreen"][PlayerPrefs.GetString("language")]; 
                }
                SettingPanel.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["goback"][PlayerPrefs.GetString("language")]; 
               
                if (PlayerPrefs.GetInt("SkipDialogue", 0) <= 0)
                {
                     SettingPanel.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["skipTextmodeOFF"][PlayerPrefs.GetString("language")]; 
                }
                else
                {
                    SettingPanel.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["skipTextmodeON"][PlayerPrefs.GetString("language")]; 
                }
                SettingPanel.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["settings"][PlayerPrefs.GetString("language")]; 
                ControlPanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["keyboard"][PlayerPrefs.GetString("language")]; 
                ControlPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["gamepad"][PlayerPrefs.GetString("language")]; 
                ControlPanel.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["goback"][PlayerPrefs.GetString("language")]; 
                slider = SoundPanel.transform.GetChild(0).gameObject.GetComponent<Slider>();
                slider.value = PlayerPrefs.GetFloat("sfxSound",0.4f);
                sliderMusic = SoundPanel.transform.GetChild(1).gameObject.GetComponent<Slider>();
                sliderMusic.value = PlayerPrefs.GetFloat("MusicSound",0.02f);
                  SoundPanel.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["SFX"][PlayerPrefs.GetString("language")]; 
                  SoundPanel.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["music"][PlayerPrefs.GetString("language")]; 
                  SoundPanel.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["audio"][PlayerPrefs.GetString("language")]; 
                  SoundPanel.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["goback"][PlayerPrefs.GetString("language")]; 
                  SoundPanel.SetActive(false);
                  ControlPanel.SetActive(false);
                  PCPanel.SetActive(false);
                  JoystickPanel.SetActive(false);
           EventSystem.current.SetSelectedGameObject(null);
            menuPanel.gameObject.SetActive(false);
            waitingForKey = false;
            first = true;
    
        
    }
    
     void OnEnable()
    {
        if (first)
        {
                ButtonAttack.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["LeftMouse"][PlayerPrefs.GetString("language")]; 

                ButtonAction.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ImportText.allPhrases["RightMouse"][PlayerPrefs.GetString("language")]; 
                
                PCPanel.transform.GetChild(10).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["goback"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(11).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["jump"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["down"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(13).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["left"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(14).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["right"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(15).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["dash"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(16).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["ulti"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(17).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["accept"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(18).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["escape"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(19).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["attack"][PlayerPrefs.GetString("language")]; 
                PCPanel.transform.GetChild(20).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["action"][PlayerPrefs.GetString("language")]; 
                
                JoystickPanel.transform.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["goback"][PlayerPrefs.GetString("language")]; 
                JoystickPanel.transform.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["jumpAccept"][PlayerPrefs.GetString("language")]; 
                JoystickPanel.transform.GetChild(8).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["dash"][PlayerPrefs.GetString("language")]; 
                JoystickPanel.transform.GetChild(9).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["ulti"][PlayerPrefs.GetString("language")]; 
                JoystickPanel.transform.GetChild(10).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["escape"][PlayerPrefs.GetString("language")]; 
                JoystickPanel.transform.GetChild(11).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["attack"][PlayerPrefs.GetString("language")]; 
                JoystickPanel.transform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["action"][PlayerPrefs.GetString("language")]; 
                
                SettingPanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["audio"][PlayerPrefs.GetString("language")]; 
                SettingPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["controls"][PlayerPrefs.GetString("language")]; 
                if ( Screen.fullScreen)
                {
                     SettingPanel.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["window"][PlayerPrefs.GetString("language")]; 
                }
                else
                {
                    SettingPanel.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["fullscreen"][PlayerPrefs.GetString("language")]; 
                }
                 SettingPanel.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["goback"][PlayerPrefs.GetString("language")]; 
                if (PlayerPrefs.GetInt("SkipDialogue", 0) <= 0)
                {
                     SettingPanel.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["skipTextmodeOFF"][PlayerPrefs.GetString("language")]; 
                }
                else
                {
                    SettingPanel.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["skipTextmodeON"][PlayerPrefs.GetString("language")]; 
                }
                SettingPanel.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["settings"][PlayerPrefs.GetString("language")]; 
                ControlPanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["keyboard"][PlayerPrefs.GetString("language")]; 
                ControlPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["gamepad"][PlayerPrefs.GetString("language")]; 
                ControlPanel.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["goback"][PlayerPrefs.GetString("language")];
                SoundPanel.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["SFX"][PlayerPrefs.GetString("language")]; 
                SoundPanel.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["music"][PlayerPrefs.GetString("language")]; 
                SoundPanel.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["audio"][PlayerPrefs.GetString("language")]; 
                SoundPanel.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["goback"][PlayerPrefs.GetString("language")]; 
        }
    }
    
    public void changeVolume()
    {
        
        if (slider !=null && canChangeVolume)
        {
        SoundManager.SM.volume = slider.value;
        
        PlayerPrefs.SetFloat("sfxSound",slider.value);
        SoundManager.SM.makeDefaultVolume();
        }
    }
        public void changeVolumeMusic()
    {
        
        if (sliderMusic !=null && canChangeVolume)
        {
        MusicManager.MM.volume = sliderMusic.value;
        
        PlayerPrefs.SetFloat("MusicSound",sliderMusic.value);
        MusicManager.MM.makeDefaultVolume();
        }
       
    }
    
    
    public void continueCommand()
    {
         setSelected = true;
             menuPanel.gameObject.SetActive(false);
            Time.timeScale = 1.0f;  
             SoundPanel.SetActive(false);
                  SettingPanel.SetActive(true);
                   ControlPanel.SetActive(false);
                  PCPanel.SetActive(false);
    }
    
    public void fullScreenOR()
    {
        GameManager.GM.SetRes(true);
         if ( Screen.fullScreen)
                {
                     SettingPanel.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["fullscreen"][PlayerPrefs.GetString("language")]; 
                }
                else
                {
                    SettingPanel.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["window"][PlayerPrefs.GetString("language")]; 
                }
    }
    
     public void allowTextSkio()
    {
         if (PlayerPrefs.GetInt("SkipDialogue", 0) <= 0)
         {
                PlayerPrefs.SetInt("SkipDialogue", 1);
                SettingPanel.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["skipTextmodeON"][PlayerPrefs.GetString("language")]; 
         }
         else
         {
             PlayerPrefs.SetInt("SkipDialogue", 0);
             SettingPanel.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = ImportText.allPhrases["skipTextmodeOFF"][PlayerPrefs.GetString("language")]; 
         }
    }


    // Update is called once per frame
    void Update()
    {
        
            
        if (SoundPanel.activeSelf && EventSystem.current.currentSelectedGameObject != sliderMusic.gameObject &&
             EventSystem.current.currentSelectedGameObject != slider.gameObject
             && EventSystem.current.currentSelectedGameObject != SoundPanel.transform.GetChild(5).gameObject)
        {
            EventSystem.current.SetSelectedGameObject(slider.gameObject);
        }
        
        
 
        
        //SETTINGS PANEL
          if (SettingPanel.activeSelf && EventSystem.current.currentSelectedGameObject != SettingPanel.transform.GetChild(0).gameObject &&
             EventSystem.current.currentSelectedGameObject != SettingPanel.transform.GetChild(1).gameObject &&
             EventSystem.current.currentSelectedGameObject != SettingPanel.transform.GetChild(2).gameObject &&
             EventSystem.current.currentSelectedGameObject != SettingPanel.transform.GetChild(3).gameObject &&
             EventSystem.current.currentSelectedGameObject != SettingPanel.transform.GetChild(4).gameObject)
        {
            EventSystem.current.SetSelectedGameObject(SettingPanel.transform.GetChild(0).gameObject);
        }
        
           //CHOOSE KEYBOARD OR GAMEPAD CONTROL
          if (ControlPanel.activeSelf && EventSystem.current.currentSelectedGameObject != ControlPanel.transform.GetChild(0).gameObject &&
             EventSystem.current.currentSelectedGameObject != ControlPanel.transform.GetChild(1).gameObject &&
             EventSystem.current.currentSelectedGameObject != ControlPanel.transform.GetChild(2).gameObject )
        {
            EventSystem.current.SetSelectedGameObject(ControlPanel.transform.GetChild(0).gameObject);
        }
        
        
           //KEYBOARD CONTROL
           if (PCPanel.activeSelf && EventSystem.current.currentSelectedGameObject != PCPanel.transform.GetChild(0).gameObject &&
             EventSystem.current.currentSelectedGameObject != PCPanel.transform.GetChild(1).gameObject &&
             EventSystem.current.currentSelectedGameObject != PCPanel.transform.GetChild(2).gameObject&&
             EventSystem.current.currentSelectedGameObject != PCPanel.transform.GetChild(3).gameObject&&
             EventSystem.current.currentSelectedGameObject != PCPanel.transform.GetChild(4).gameObject&&
             EventSystem.current.currentSelectedGameObject != PCPanel.transform.GetChild(5).gameObject&&
             EventSystem.current.currentSelectedGameObject != PCPanel.transform.GetChild(6).gameObject&&
             EventSystem.current.currentSelectedGameObject != PCPanel.transform.GetChild(7).gameObject&&
             EventSystem.current.currentSelectedGameObject != PCPanel.transform.GetChild(10).gameObject)
        {
            EventSystem.current.SetSelectedGameObject(PCPanel.transform.GetChild(0).gameObject);
        }
          //GAMEPAD CONTROL
         if (JoystickPanel.activeSelf && EventSystem.current.currentSelectedGameObject != JoystickPanel.transform.GetChild(0).gameObject &&
             EventSystem.current.currentSelectedGameObject != JoystickPanel.transform.GetChild(1).gameObject &&
             EventSystem.current.currentSelectedGameObject != JoystickPanel.transform.GetChild(2).gameObject&&
             EventSystem.current.currentSelectedGameObject != JoystickPanel.transform.GetChild(3).gameObject&&
             EventSystem.current.currentSelectedGameObject != JoystickPanel.transform.GetChild(4).gameObject&&
             EventSystem.current.currentSelectedGameObject != JoystickPanel.transform.GetChild(5).gameObject&&
             EventSystem.current.currentSelectedGameObject != JoystickPanel.transform.GetChild(6).gameObject)
        {
            EventSystem.current.SetSelectedGameObject(JoystickPanel.transform.GetChild(0).gameObject);
        }
        
         if (cantClickGui && btnC != null)
        {
            
            EventSystem.current.SetSelectedGameObject(btnC.gameObject);
           // btnC.color = Color.white;
           //  waitingForKey = false;
           //  cantClickGui = false;
        }

            
        if (((menuPanel.gameObject.activeSelf && 
        (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(GameManager.GM.accept) || Input.GetKeyUp(GameManager.GM.jumpJC)) && GameManager.GM.inputOn) 
        || 
        (GameManager.GM.alternativeInput && (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(GameManager.GM.accept) || Input.GetKeyUp(GameManager.GM.jumpJC))))
        && !GameManager.GM.textRunning && (EventSystem.current.currentSelectedGameObject != slider.gameObject && EventSystem.current.currentSelectedGameObject  != sliderMusic.gameObject) && !cantClickGui ){
             EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
         
        }
    }
    
    void OnGUI()
    {
    
      keyEvent = Event.current;



          /*
          if (keyEvent.isMouse && keyEvent.button == 0 && waitingForKey){
              newKey = KeyCode.Mouse0;
              waitingForKey = false;
          }
          if (keyEvent.isMouse && keyEvent.button == 1 && waitingForKey){
              newKey = KeyCode.Mouse1;
              waitingForKey = false;
          }
            
          if (keyEvent.shift && waitingForKey){
              newKey = KeyCode.LeftShift;
              waitingForKey = false;
          }
        */
       if ((Input.anyKey || keyEvent.functionKey) && waitingForKey && Controller.joystickController.joystick != 1)
       {
   
          if (Input.GetKey(KeyCode.LeftShift))
          {  
                newKey = KeyCode.LeftShift;
              waitingForKey = false;
                }
                else if (Input.GetKey(KeyCode.RightShift))
                {
                newKey = KeyCode.RightShift;
                  waitingForKey = false;
                }
          else if (keyEvent.isKey)
          {
          newKey = keyEvent.keyCode;
           waitingForKey = false;
          }
       }
       
     for (int i = 2; i < 7; i++)
       {
            if (Input.GetMouseButton(i) && waitingForKey && Controller.joystickController.joystick != 1)
            {
               
                newKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Mouse"+i.ToString());
                 Debug.Log(newKey.ToString());
                 waitingForKey = false;
            }
       }
       
       for (int i = 0; i < 20; i++) {
        if (Input.GetKey("joystick button "+i.ToString()) && waitingForKey && Controller.joystickController.joystick == 1)
            {
                Debug.Log(newKey.ToString());
                 newKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), "JoystickButton"+i.ToString());
                  waitingForKey = false;
            }
       }
       
           

                 
              
              
        

           
       
               
       
         
      
    }
    
    public void StarAssignment(string keyName){
        
        if (!waitingForKey)
        {   
            
            StartCoroutine(AssignKey(keyName));
        }
        
    }
    
    public void SendText(TextMeshProUGUI text){
        
        buttonText = text;
    }
    
    public void buttonColor(Image btn)
    {
        btnC = btn;
        btnC.color = Color.red;
    }
    
    IEnumerator WaitForKey(){
        while(keyPressed != 1){
          
            if (Controller.joystickController.joystick != 1)
            {
               for (int i = 2; i < 7; i++)
                 {
                    if (Input.GetMouseButtonDown(i))
                      {
                        
                      }
                      else if (Input.GetMouseButtonUp(i))
                      {
                           keyPressed +=1;
                           break;
                      }
                      else if (Input.anyKey)
                      {
                           keyPressed +=1;
                           break;
                      }
                  }
            }
            else
            {
               for (int i = 0; i < 20; i++) {
                 if (Input.GetKey("joystick button "+i.ToString()))
                 {
                 keyPressed +=1;
                  }
               }
            }
            

           
              
            yield return null;
        }
         keyPressed = 0;
            
                  StartCoroutine(unlock());
        
    }
    
    public IEnumerator AssignKey(string keyName){
     
       waitingForKey = true;
        cantClickGui = true;
        yield return WaitForKey();
        
       
       if (PCPanel.activeSelf && newKey.ToString() != "None" && !newKey.ToString().Contains("Joystick") )
             {
        switch(keyName)
        {
          case "jump":
             GameManager.GM.jump = newKey;
             buttonText.text = GameManager.GM.jump.ToString();
             PlayerPrefs.SetString("JumpKey", GameManager.GM.jump.ToString());    
             break;      
          case "down":
             GameManager.GM.down = newKey;
             buttonText.text = GameManager.GM.down.ToString();
             PlayerPrefs.SetString("DownKey", GameManager.GM.down.ToString());
             break;  
          case "left":
             GameManager.GM.left = newKey;
             buttonText.text = GameManager.GM.left.ToString();
             PlayerPrefs.SetString("LeftKey", GameManager.GM.left.ToString());
             break; 
          case "right":
             GameManager.GM.right = newKey;
             buttonText.text = GameManager.GM.right.ToString();
             PlayerPrefs.SetString("RightKey", GameManager.GM.right.ToString());
             break; 
          case "dash":
             GameManager.GM.dodge = newKey;
             buttonText.text = GameManager.GM.dodge.ToString();
             PlayerPrefs.SetString("DodgeKey", GameManager.GM.dodge.ToString());
             break;    
          case "ulti":
             GameManager.GM.ult = newKey;
             buttonText.text = GameManager.GM.ult.ToString();
             PlayerPrefs.SetString("UltKey", GameManager.GM.ult.ToString());
             break;      
          case "accept":
             GameManager.GM.accept = newKey;
             buttonText.text = GameManager.GM.accept.ToString();
             PlayerPrefs.SetString("AcceptKey", GameManager.GM.accept.ToString());
             break;      
         case "escape":
             GameManager.GM.escape = newKey;
             buttonText.text = GameManager.GM.escape.ToString();
             PlayerPrefs.SetString("EscapeKey", GameManager.GM.escape.ToString());
             break;               
            
        }
       }
       
        if (JoystickPanel.activeSelf && newKey.ToString() != "None" && newKey.ToString().Contains("Joystick") )
           {
        switch(keyName)
        {
          case "jumpJC":
             GameManager.GM.jumpJC = newKey;
             buttonText.text = GameManager.GM.jumpJC.ToString();
             PlayerPrefs.SetString("JumpJC", GameManager.GM.jumpJC.ToString());    
             break;       
          case "dashJC":
             GameManager.GM.dodgeJC = newKey;
             buttonText.text = GameManager.GM.dodgeJC.ToString();
             PlayerPrefs.SetString("DodgeKeyJC", GameManager.GM.dodgeJC.ToString());
             break;    
          case "ultiJC":
             GameManager.GM.ultJC = newKey;
             buttonText.text = GameManager.GM.ultJC.ToString();
             PlayerPrefs.SetString("UltKeyJC", GameManager.GM.ultJC.ToString());
             break;       
         case "escapeJC":
             GameManager.GM.escapeJC = newKey;
             buttonText.text = GameManager.GM.escapeJC.ToString();
             PlayerPrefs.SetString("EscapeKeyJC", GameManager.GM.escapeJC.ToString());
             break;      
         case "attackJC":
             GameManager.GM.attackJC = newKey;
             buttonText.text = GameManager.GM.attackJC.ToString();
             PlayerPrefs.SetString("AttackJC", GameManager.GM.attackJC.ToString());
             break;       
         case "actionJC":
             GameManager.GM.actionJC = newKey;
             buttonText.text = GameManager.GM.actionJC.ToString();
             PlayerPrefs.SetString("ActionJC", GameManager.GM.actionJC.ToString());
             break;               
            
        }
       }
       
       
        btnC.color = Color.white;
   
     
        yield return null;
    }
    
    IEnumerator unlock()
    { 
    float pauseEndTime = Time.realtimeSinceStartup + 0.15f;
      while(Time.realtimeSinceStartup < pauseEndTime)
      {
          
            
          yield return null;
         
      }
      cantClickGui = false;
    }
}
