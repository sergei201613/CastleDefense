using UnityEngine;

public class PlayerCharacter : Character
{
    private GameMode _gm;

    protected override void Awake()
    {
        base.Awake();

        _gm = FindObjectOfType<GameMode>();
    }

    protected override void OnDied()
    {
        _gm.EndGame(false);
    }
}