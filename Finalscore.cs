using UnityEngine;
using TMPro;

public class FinalSceneScript : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        // Load the score saved in the PlayerPrefs
        float finalScore = PlayerPrefs.GetFloat("FinalScore", 0.0f);

        // Display the final score in the UI
        finalScoreText.text = "Final Score: " + Mathf.Round(finalScore);
    }
}
