using System;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public bool HasEnemiesForHit => _enemiesInMelee.enemies.Count > 0;
    public bool HasEnemiesForShot => _enemiesInLongRange.enemies.Count > 0;

    [SerializeField] private int _damage;
    [SerializeField] private float _hitRate;
    [SerializeField] private float _shotRate;
    [SerializeField] private Arrow _arrowPrefab;
    [SerializeField] private Character _character;
    [SerializeField] private Transform _arrowSpawnPoint;
    [SerializeField] private bool _longRangeAttack = false;
    [SerializeField] private EnemyDetection _enemiesInMelee;
    [SerializeField] private EnemyDetection _enemiesInLongRange;
    [SerializeField] private Sword _sword;
    [SerializeField] private CharacterMovement _movement;

    private float HitDelay => 1 / _hitRate;
    private float ShotDelay => 1 / _shotRate;
    private bool CanShot => !_movement.IsMoving;

    private float _lastHitTime = float.NegativeInfinity;
    private float _lastShotTime = float.NegativeInfinity;

    private void Update()
    {
        HandleHiting();
        if (_longRangeAttack) HandleShoting();
    }

    private void OnEnable()
    {
        _sword.Hited += OnSwordHited;
    }
    
    private void OnDisable()
    {
        _sword.Hited -= OnSwordHited;
    }

    private void OnSwordHited()
    {
        Hit();
    }

    private void HandleHiting()
    {
        if (Time.time > _lastHitTime + HitDelay)
        {
            if (_enemiesInMelee.enemies.Count > 0)
            {
                _sword.StartHitAnim();
                _lastHitTime = Time.time;
            }
        }
    }

    private void HandleShoting()
    {
        if (Time.time > _lastShotTime + ShotDelay)
        {
            if (_enemiesInLongRange.enemies.Count > 0 
                && _enemiesInMelee.enemies.Count == 0
                && CanShot)
            {
                Shot();
                _lastShotTime = Time.time;
            }
        }
    }

    private void Shot()
    {
        var arrow = Instantiate(_arrowPrefab, _arrowSpawnPoint.position, Quaternion.identity);
        arrow.Init(_character.TeamId);
    }

    private void Hit()
    {
        if (_enemiesInMelee.enemies.Count > 0)
        {
            _enemiesInMelee.enemies[0].TakeDamage(_damage);
        }
    }
}