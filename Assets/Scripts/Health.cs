using UnityEngine;

public class Health : MonoBehaviour
{
    public event System.Action<float> HealthChanged;
    public event System.Action Died;

    [SerializeField] private int _maxHealth = 100;

    private int _health = 0;

    private void Start()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(_health / _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        _health = Mathf.Clamp(_health - damage, 0, _maxHealth);

        HealthChanged?.Invoke((float)_health / _maxHealth);
        if (_health == 0) Died?.Invoke();
    }
}