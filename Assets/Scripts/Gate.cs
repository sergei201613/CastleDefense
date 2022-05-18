using UnityEngine;

public class Gate : MonoBehaviour
{
    private GameMode _gm;

    private void Awake()
    {
        _gm = FindObjectOfType<GameMode>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var enemy))
        {
            _gm.EndGame(false);
        }
    }
}