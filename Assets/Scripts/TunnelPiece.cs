using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class TunnelPiece : MonoBehaviour
{
    TunnelManager _tunnelManager;
    [SerializeField] Transform _endPoint;
    ObjectPool<TunnelPiece> _pool;
    [SerializeField] float _speed = 2.0f;
    Vector3 _direction = new Vector3(1, 0, 0);
    Rigidbody _rb;

    private void Awake()
    {
        _tunnelManager = FindObjectOfType<TunnelManager>();
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _rb.velocity = _direction * _speed;
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("EndWall"))
        { 
            Destroy(gameObject);
            _tunnelManager.SetIsPieceDestroyed(true);
        }
    }
    public Transform GetEndPoint()
    { 
        return _endPoint;
    }
    public float GetDistance()
    {
        float distance = Vector3.Distance(gameObject.transform.position,_endPoint.position);
        Debug.Log("Piece Lenght: "+distance);
        return distance;
    }

    public void SetPool(ObjectPool<TunnelPiece> pool)
    {
        _pool = pool;
    }
}
