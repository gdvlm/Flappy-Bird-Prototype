using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI defeatScoreText;
    [SerializeField] private TextMeshProUGUI defeatHighScoreText;

    private int _currentScore = 0;
    private int _highestScore = 0;

    public void IncrementScore()
    {
        SetCurrentScore(_currentScore + 1);

        if (_currentScore > _highestScore)
        {
            _highestScore = _currentScore;
            defeatHighScoreText.text = _highestScore.ToString();
        }
    }

    public void ResetScore()
    {
        SetCurrentScore(0);
    }

    private void SetCurrentScore(int score)
    {
        _currentScore = score;
        scoreText.text = score.ToString();
        defeatScoreText.text = score.ToString();        
    }
}
