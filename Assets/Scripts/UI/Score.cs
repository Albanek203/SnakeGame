using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Score : MonoBehaviour {
    [SerializeField]
    private SnakeHead _snakeHead;

    private TMP_Text _score;
    private int _scoreValue;

    public int ScoreValue => _scoreValue;

    private void Awake() { _score = GetComponent<TMP_Text>(); }

    private void OnEnable() { _snakeHead.BlockCollided += OnBlockCollided; }

    private void OnDisable() { _snakeHead.BlockCollided -= OnBlockCollided; }

    private void OnBlockCollided() {
        _scoreValue++;
        _score.text = _scoreValue.ToString();
        if (PlayerPrefs.GetInt("GrateScore") < _scoreValue) PlayerPrefs.SetInt("GrateScore", _scoreValue);
    }
}