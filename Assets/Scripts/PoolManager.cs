using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    [SerializeField] TunnelPiece _tunnelPiecePrefab;

    ObjectPool<TunnelPiece> _tunnelPiecePool;

    public static PoolManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        _tunnelPiecePool = new ObjectPool<TunnelPiece>(AddNewBlasterShotToPool,
            t => t.gameObject.SetActive(true),
            t => t.gameObject.SetActive(false));
    }

    TunnelPiece AddNewBlasterShotToPool()
    {
        var tunnel = Instantiate(_tunnelPiecePrefab);
        tunnel.SetPool(_tunnelPiecePool);
        return tunnel;
    }

    public TunnelPiece GetTunnelPiece()
    {
        return _tunnelPiecePool.Get();
    }

}
