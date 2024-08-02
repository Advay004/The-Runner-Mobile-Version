using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Replaym : MonoBehaviour
{
    
    void Start()
    {
       
    }

    
    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
