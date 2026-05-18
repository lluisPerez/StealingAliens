using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
using TMPro;


public class GameOver : MonoBehaviour
{
    
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    private ScoreManager scoreManager;


  
    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverPanel.SetActive(true);
            if (scoreText != null && scoreManager != null)
            {
                scoreText.text = "Final Score: " + scoreManager.score;
            }
        }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
