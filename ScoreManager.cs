using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;                                            


public class ScoreManager : MonoBehaviour
{
    private PlayerControll playerControllScript;
    public TextMeshProUGUI scoreText;
    
     
    public float score = 0.0f;
    
    public float scoreIncrementRate = 10.0f; // Adjust this value to control how fast the score increases
    void Start(){
        playerControllScript=GameObject.Find("player").GetComponent<PlayerControll>();
        playerControllScript.GameOver=false;
        playerControllScript.isOnGround=true;
        
    }

    void Update()
    { 
         if(playerControllScript.GameOver == false){
              // Increase the score based on Time.deltaTime
              score += scoreIncrementRate * Time.deltaTime;
         }
        else if( playerControllScript.GameOver == true){
            score+=0;
            LoadNextScene();
        
        }
         // Optionally, you can round the score or display it in some way
        // For example, you might want to update a UI element with the current score.
        UpdateScoreUI();
        
    }
    
    void UpdateScoreUI()
    {
        // Implement your code to update the UI with the current score here
        // For example, if you have a Text component named scoreText:
     
        scoreText.text = "Score: " + Mathf.Round(score);
    }
    public void SaveScore()
    {
        // Save the score to PlayerPrefs
        PlayerPrefs.SetFloat("FinalScore", score);
        PlayerPrefs.Save();
    }
    public void LoadNextScene()
    {
        // Call this method to load the next scene
        SaveScore();
        
    }
  
   
}
