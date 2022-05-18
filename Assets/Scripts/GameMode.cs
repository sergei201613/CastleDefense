using UnityEngine;

public class GameMode : MonoBehaviour
{
    [SerializeField] private int _enemiesToWin = 20;

    public int EnemiesToWin => _enemiesToWin;

    public event System.Action<bool> GameEnded;

    private int _enemyDied = 0;

    public void EndGame(bool isPlayerWon)
    {
        GameEnded?.Invoke(isPlayerWon);
    }

    public void OnEnemyDied()
    {
        _enemyDied++;

        if (_enemyDied >= _enemiesToWin) EndGame(true);
    }
}