using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuManager : MonoBehaviour
{
    
   
   
     
    public void PlayGame(){
        
        SceneManager.LoadScene(1);
        
        
    }
    public void replay(){
        
        SceneManager.LoadScene(1);
    }
    public void Quit(){
        Application.Quit();
    }

     
}
   
//SceneManager.GetActiveScene().buildIndex+1