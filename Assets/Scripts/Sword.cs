using UnityEngine;

public class Sword : MonoBehaviour
{
    public event System.Action Hited;

    private Animator _animator;
    private int _hitAnim = Animator.StringToHash("Hit");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartHitAnim()
    {
        _animator.SetTrigger(_hitAnim);
    }
    
    public void Anim_OnHit()
    {
        Hited?.Invoke();
    }
}