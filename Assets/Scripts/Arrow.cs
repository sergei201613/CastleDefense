using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed = 15f;

    private Rigidbody2D _rb;
    private int _teamId = 0;
    private int _arrowDamage = 10;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.position += Vector2.right * _speed * Time.deltaTime;
    }

    public void Init(int teamId)
    {
        _teamId = teamId;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Character>(out var character))
        {
            if (character.TeamId != _teamId)
            {
                character.TakeDamage(_arrowDamage);
                Destroy(gameObject);
            }
        }
    }
}