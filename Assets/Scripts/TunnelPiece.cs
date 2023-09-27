using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class TunnelPiece : MonoBehaviour
{
    [SerializeField] float _speed = 2.0f;
    [SerializeField] float _maxLifetime = 4f;

    ObjectPool<TunnelPiece> _pool;
    Vector3 _direction;
    Rigidbody _rb;
    private float _selfDestructTime;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        _rb.velocity = _direction * _speed;
        if (Time.time >= _selfDestructTime)
            SelfDestruct();
    }
    void SelfDestruct()
    {
        _pool.Release(this);
    }

    public void Launch( Vector3 position)
    {
        transform.position = position;
        _selfDestructTime = Time.time + _maxLifetime;
    }
    public void SetPool(ObjectPool<TunnelPiece> pool)
    {
        _pool = pool;
    }
}
