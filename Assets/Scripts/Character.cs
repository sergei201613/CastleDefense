using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int TeamId => _teamId;

    [SerializeField] private int _teamId = 0;

    private Health _health;

    protected virtual void Awake()
    {
        if (TryGetComponent<Health>(out var health))
        {
            _health = health;
        }
        else
        {
            _health = gameObject.AddComponent<Health>();
        }
    }

    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    protected virtual void OnDied()
    {
        Destroy(gameObject);
    }

    internal void TakeDamage(object arrowDamage)
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}