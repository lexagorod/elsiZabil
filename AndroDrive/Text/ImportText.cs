using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class ImportText : MonoBehaviour
{
  
     
    public static Dictionary<string, Dictionary<string,string>> allPhrases = new Dictionary<string, Dictionary<string,string>>();
    // Start is called before the first frame update
    [RuntimeInitializeOnLoadMethod]
    public static void OnRuntimeMethodLoad()
    {
        
        int hasPlayed = PlayerPrefs.GetInt("HasPlayed", 0);
 
         if( hasPlayed != 1 )
            {
          PlayerPrefs.SetInt("HasPlayed", 1);
          if (Application.systemLanguage == SystemLanguage.Russian)
        {
                PlayerPrefs.SetString("language","Ru");
        }
        else
        {
            PlayerPrefs.SetString("language","En");
        }
            }
       
    
        string[] lines = File.ReadAllLines(Application.dataPath + "/StreamingAssets/pharasesAll.csv");
        foreach (string line in lines)
        {
            var values1 = line.Split(';');
            allPhrases[values1[0]] =  new Dictionary<string,string>(){{"Ru",values1[1]}, {"En", values1[2]}};
         }
        /*
    using(var reader = new StreamReader("Assets/pharasesAll.csv",  Encoding.Default))
    {       var line1 = reader.ReadLine();
            var values1 = line1.Split(';');
            allPhrases[values1[0]] =  new Dictionary<string,string>(){{"Ru",values1[1]}, {"En", values1[2]}};
           
        while (reader.ReadLine() != null)
        {
            var line = reader.ReadLine();
            var values = line.Split(';');
            allPhrases[values[0]] =  new Dictionary<string,string>(){{"Ru",values[1]}, {"En", values[2]}};
            
          //  Debug.Log(values[0]);
            }*/
          
       
   // reader.Close();
/*         
            lang
            listB.Add(values[1]);
            listC.Add(values[2]);
            
            Debug.Log(listA[0]);
               Debug.Log(listB[0]);
                  Debug.Log(listC[0]);
                     Debug.Log(listA[1]); */
      //  }
    }
        
    

    
    private static string getPath(){

    return Application.dataPath;
      
      /*
#elif UNITY_ANDROID
return Application.persistentDataPath;// +fileName;
#elif UNITY_IPHONE
return GetiPhoneDocumentsPath();// +"/"+fileName;
#else
return Application.dataPath;// +"/"+ fileName;
#endif
*/}
}
