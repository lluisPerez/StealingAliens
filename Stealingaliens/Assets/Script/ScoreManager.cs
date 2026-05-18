using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI ScoreText; 
    public float score;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        ScoreText.text = "Score: " + score;
    }
}
