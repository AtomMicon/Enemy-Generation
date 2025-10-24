using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;
    
    private Vector3 _moveDirection;

    public void Initialize(Vector3 direction)
    {
        _moveDirection = direction.normalized;
    }

    void Update()
    {
        transform.position += _moveDirection * _moveSpeed * Time.deltaTime;
    }
}
