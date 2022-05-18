using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public bool IsMoving => Mathf.Abs(_input.GetDeltaMovement()) > float.Epsilon;

    [SerializeField] private float _speed = 5f;

    private ICharacterInput _input;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _input = GetComponent<ICharacterInput>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.position += new Vector2(_input.GetDeltaMovement() * _speed * Time.deltaTime, 0f);
    }
}