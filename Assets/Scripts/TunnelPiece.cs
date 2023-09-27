using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class TunnelPiece : MonoBehaviour
{
    [SerializeField] float _speed = 2.0f;
    Vector3 _destroyPoint ;
    ObjectPool<TunnelPiece> _pool;
    Vector3 _direction;
    Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _direction = new Vector3(1, 0, 0);
        _destroyPoint = new Vector3(100,100,100);
    }
    void Update()
    {
        _rb.velocity =  _direction * _speed;
        if (Vector3.Distance(_rb.transform.position, _destroyPoint) < 1.0f)
            Destruct();
        Debug.Log(Vector3.Distance(_rb.transform.position, _destroyPoint));
    }
    public void Destruct()
    {
        // _pool.Release(this);
        Debug.Log("Destroyed");
        
             Destroy(gameObject);
    }

    public void Launch( Vector3 position, Vector3 endPosition )
    {
        transform.position = position;
        _destroyPoint = endPosition;
        Debug.Log(endPosition);
    }
    public void SetPool(ObjectPool<TunnelPiece> pool)
    {
        _pool = pool;
    }
}
