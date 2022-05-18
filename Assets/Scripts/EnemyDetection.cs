using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private Character _character;

    public readonly List<Character> enemies = new List<Character>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Character>(out var character))
        {
            if (character.TeamId != _character.TeamId)
            {
                if (!enemies.Contains(character))
                    enemies.Add(character);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Character>(out var character))
        {
            enemies.Remove(character);
        }
    }
}