using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class TunnelPiece : MonoBehaviour
{
    ObjectPool<TunnelPiece> _pool;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("EndWall"))
            Destroy(gameObject);
    }

    public void SetPool(ObjectPool<TunnelPiece> pool)
    {
        _pool = pool;
    }
}
