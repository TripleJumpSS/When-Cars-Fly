using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    [SerializeField] TunnelPiece _tunnelPieceWhitePrefab;
    [SerializeField] TunnelPiece _tunnelPieceRedPrefab;
    [SerializeField] TunnelPiece _tunnelPieceBluePrefab;
    [SerializeField] TunnelPiece _tunnelPieceGreenPrefab;

    ObjectPool<TunnelPiece> _tunnelPieceWhitePool;
    ObjectPool<TunnelPiece> _tunnelPieceRedPool;
    ObjectPool<TunnelPiece> _tunnelPieceBluePool;
    ObjectPool<TunnelPiece> _tunnelPieceGreenPool;
    ListPool<TunnelPiece> _tunnelPieces;
    
    public static PoolManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        _tunnelPieceWhitePool = new ObjectPool<TunnelPiece>(AddNewTunnelPieceWhiteToPool,
            t => t.gameObject.SetActive(true),
            t => t.gameObject.SetActive(false));

        _tunnelPieceRedPool = new ObjectPool<TunnelPiece>(AddNewTunnelPiecetRedToPool,
            t => t.gameObject.SetActive(true),
            t => t.gameObject.SetActive(false));

        _tunnelPieceBluePool = new ObjectPool<TunnelPiece>(AddNewTunnelPieceBlueToPool,
            t => t.gameObject.SetActive(true),
            t => t.gameObject.SetActive(false));

        _tunnelPieceGreenPool = new ObjectPool<TunnelPiece>(AddNewTunnelPieceGreenToPool,
            t => t.gameObject.SetActive(true),
            t => t.gameObject.SetActive(false));
    }
    public List<TunnelPiece> Test(TunnelPiece[] pieces) 
    {
        var tunnelPieces = ListPool<TunnelPiece>.Get();

        using (var pooledObject = ListPool<TunnelPiece>.Get(out List<TunnelPiece> tempList))
        {
            for (int i=0; i < pieces.Length; ++i)
            {
                tempList.Add(pieces[i]);
            }
        }
        return tunnelPieces;
    }
    TunnelPiece AddNewTunnelPieceWhiteToPool()
    {
        var tunnel = Instantiate(_tunnelPieceWhitePrefab);
        tunnel.SetPool(_tunnelPieceWhitePool);
        return tunnel;
    }
    TunnelPiece AddNewTunnelPiecetRedToPool()
    {
        var tunnel = Instantiate(_tunnelPieceRedPrefab);
        tunnel.SetPool(_tunnelPieceRedPool);
        return tunnel;
    }
    TunnelPiece AddNewTunnelPieceBlueToPool()
    {
        var tunnel = Instantiate(_tunnelPieceBluePrefab);
        tunnel.SetPool(_tunnelPieceBluePool);
        return tunnel;
    }
    TunnelPiece AddNewTunnelPieceGreenToPool()
    {
        var tunnel = Instantiate(_tunnelPieceGreenPrefab);
        tunnel.SetPool(_tunnelPieceGreenPool);
        return tunnel;
    }
    public TunnelPiece GetTunnelPiece()
    {
        return _tunnelPieceWhitePool.Get();
    }

}
