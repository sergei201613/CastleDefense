using System;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private CharacterCombat _combat;

    private EnemyInput _input;
    private EnemyState _state = EnemyState.Moving;
    private GameMode _gm;

    private void Start()
    {
        _input = GetComponent<EnemyInput>();
        _gm = FindObjectOfType<GameMode>();

        ChangeState(EnemyState.Moving);
    }

    protected override void OnDied()
    {
        base.OnDied();

        _gm.OnEnemyDied();
    }

    private void Update()
    {
        if (_combat.HasEnemiesForHit)
            ChangeState(EnemyState.Attacking);
        else
            ChangeState(EnemyState.Moving);
    }

    private void ChangeState(EnemyState state)
    {
        _state = state;

        switch (_state)
        {
            case EnemyState.Moving:
                _input.SetDeltaMovement(-1f);
                break;
            case EnemyState.Attacking:
                _input.SetDeltaMovement(0f);
                break;
            default:
                break;
        }
    }
}