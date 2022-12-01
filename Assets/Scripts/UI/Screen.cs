using TMPro;
using UnityEngine;

public class Screen : MonoBehaviour {
    [SerializeField]
    private Score _score;

    [SerializeField]
    private TMP_Text _scoreText;
    [SerializeField]
    private TMP_Text _grateScoreText;

    protected void ShowScore() {
        _scoreText.text = $"Your score: {_score.ScoreValue}";
        _grateScoreText.text = $"Grate score: {PlayerPrefs.GetInt("GrateScore")}";
    }
}