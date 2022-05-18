using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _minPosX = 0f;
    [SerializeField] private float _maxPosX = 0f;
    
    private Transform _target;

    private void Awake()
    {
        _target = FindObjectOfType<PlayerCharacter>().transform;
    }

    private void LateUpdate()
    {
        Vector2 pos = _target.position;
        pos.x = Mathf.Clamp(pos.x, _minPosX, _maxPosX);
        transform.position = pos;
    }
}