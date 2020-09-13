using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager DM;
    public ELEMENTS elem;
    void Awake()
    {
        DM = this;
    }


    public int index = 0;
    public string[] replici = new string[]
    {
            "Привет, хорошая погода",
            "Ну ладно..."
    };

    public void Say()
    {
        if (!isSpeaking || isWaitForKey)
        {
            Debug.Log(index);
            if (index <= replici.Length)
            {
                StopSpeaking();
                speaking = StartCoroutine(Speaking(replici[index]));
                index++;
            }
        }
       
    }
    public void StopSpeaking()
    {
        if (isSpeaking)
        {
            StopCoroutine(speaking);
        }
        speaking = null;
    }
    
    public bool isSpeaking { get { return speaking != null; } }
    [HideInInspector] public bool isWaitForKey = false;

    Coroutine speaking = null;
    IEnumerator Speaking(string speech)
    {
        speechPanel.SetActive(true);
        speechText.text = "";
        isWaitForKey = false;

        while (speechText.text != speech)
        {
            speechText.text += speech[speechText.text.Length];
            yield return new WaitForEndOfFrame();
        }

        isWaitForKey = true;
        while (isWaitForKey)
            yield return new WaitForEndOfFrame();

        StopSpeaking();
    }

 

    [System.Serializable]
    public class ELEMENTS
    {
        public GameObject speechPanel;
        public TextMeshProUGUI speechText;
        public TextMeshProUGUI buttonText;

    }

    public GameObject speechPanel { get { return elem.speechPanel; } }
    public TextMeshProUGUI speechText { get { return elem.speechText; } }
    public TextMeshProUGUI buttonText { get { return elem.buttonText; } }

    public void setText(string s)
    {
        buttonText.text = s;
    }
}
