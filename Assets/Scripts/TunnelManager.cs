using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelManager : MonoBehaviour
{
    [SerializeField] Transform _startingPoint;
    [SerializeField] Transform _endingPoint;

    

    void Awake()
    {
       
    }
    void Fire()
    {
        TunnelPiece tunnelPiece = PoolManager.Instance.GetTunnelPiece();
        tunnelPiece.Launch( _startingPoint.position);
    }
}
