using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int _currentScore = 0;
    private int _highestScore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore()
    {
        _currentScore++;
        scoreText.text = _currentScore.ToString();

        if (_currentScore > _highestScore)
        {
            _highestScore = _currentScore;
        }
    }
}
