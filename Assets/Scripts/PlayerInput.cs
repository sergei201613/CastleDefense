using UnityEngine;

public class PlayerInput : MonoBehaviour, ICharacterInput
{
    private PlayerHUD _hud;

    private void Awake()
    {
        _hud = FindObjectOfType<PlayerHUD>();
    }

    public float GetDeltaMovement()
    {
        float delta = 0;

        if (_hud.IsLeftButtonPressed) delta -= 1;
        if (_hud.IsRightButtonPressed) delta += 1;

        return delta;
    }
}