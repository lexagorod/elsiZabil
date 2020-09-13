using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class linqx : MonoBehaviour
{
    public int[] grades = { 34, 21,69, 35, 95,35,76,53};
    
    
    void Start()
    {
       
        var NewGrades = grades.Where(grade => grade >=69);
        
        foreach(var grade in NewGrades)
        {
             Debug.Log(grade);
        }
       
    }
}
