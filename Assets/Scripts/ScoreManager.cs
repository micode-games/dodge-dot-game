using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int bestScore;
    
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;


    private void Start()
    {
        LoadBestScore();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        UpdateBestScore();
    }

    private void UpdateBestScore()
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            bestScoreText.SetText("Best Score: " + bestScore.ToString());
        }
    }

    private void LoadBestScore()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.SetText("Best Score: " + bestScore.ToString());
    }

}
