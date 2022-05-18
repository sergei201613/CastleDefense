using UnityEngine;

public class EnemyInput : MonoBehaviour, ICharacterInput
{
    private float _deltaMovement = 0;

    public float GetDeltaMovement()
    {
        return _deltaMovement;
    }

    public void SetDeltaMovement(float delta)
    {
        _deltaMovement = delta;
    }
}