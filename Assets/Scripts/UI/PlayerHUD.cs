using MonoBehaviourExtensions;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHUD : MonoBehaviour
{
    public bool IsLeftButtonPressed => _leftButton.IsPressed;
    public bool IsRightButtonPressed => _rightButton.IsPressed;

    [SerializeField] private InputButton _leftButton;
    [SerializeField] private InputButton _rightButton;
    [SerializeField] private GameEndPanel _gameEndPanel;

    private GameMode _gm;

    private void Awake()
    {
        _gm = FindObjectOfType<GameMode>();
    }

    private void OnEnable()
    {
        _gm.GameEnded += OnGameEnded;
    }

    private void OnDisable()
    {
        _gm.GameEnded -= OnGameEnded;
    }

    private void OnGameEnded(bool isPlayerWon)
    {
        string text = isPlayerWon ? "You Won!" : "You Lose.";

        _gameEndPanel.Open(text);

        this.Delay(2f, () =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }
}