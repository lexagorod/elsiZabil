using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public delegate void ClickEv();
    public static event ClickEv onClick;


    public void ButtClick()
    {
        if (onClick != null)
        onClick();
    }
}
