using UnityEngine;
using UnityEngine.UI;

public class GameStateChecker : MonoBehaviour {
    [Header("Snake")]
    [SerializeField]
    private Snake _snake;
    [SerializeField]
    private SnakeHead _snakeHead;

    [Header("Finish")]
    [SerializeField]
    private FinishScreen _finishScreen;
    [SerializeField]
    private Button _reloadFinishButton;

    [Header("Game Over")]
    [SerializeField]
    private GameOverScreen _gameOverScreen;
    [SerializeField]
    private Button _reloadGameOverButton;

    private void OnEnable() {
        _snake.GameOver += OnGameOver;
        _snakeHead.Finish += OnFinish;
    }

    private void OnDisable() {
        _snake.GameOver -= OnGameOver;
        _snakeHead.Finish -= OnFinish;
    }

    private void OnFinish() {
        _finishScreen.gameObject.SetActive(true);
        _reloadFinishButton.interactable = true;
    }

    private void OnGameOver() {
        _gameOverScreen.gameObject.SetActive(true);
        _reloadGameOverButton.interactable = true;
        _snakeHead.gameObject.SetActive(false);
    }
}