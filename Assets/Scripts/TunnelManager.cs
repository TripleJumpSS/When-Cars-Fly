using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class TunnelManager : MonoBehaviour
{
    [SerializeField] Transform _startingPoint;
    [SerializeField] GameObject _endWall;
    [SerializeField] TunnelPiece[] _tunnelPieces;
    [SerializeField] TunnelPiece _lastTunnelPiece;
    [SerializeField] float _speed = 2.0f;
    bool IsPieceDestroyed = false;
    public Vector3 _lastTunnelPosition = Vector3.zero;
    

    void Update()
    {
        if (IsPieceDestroyed == true)
        {
            CreateNewPiece();
            IsPieceDestroyed = false;
        }
    }
    void OnDrawGizmos() 
    {
        Vector3 start = _startingPoint.position;
        Vector3 end = _endWall.transform.position;
        Vector3 summon = _startingPoint.position + new Vector3(5, 0, 0);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(start, end);
        Gizmos.DrawSphere(summon, 0.5f);
    }
    void CreateNewPiece()
    {
        GrabBag<TunnelPiece> grabBag = new GrabBag<TunnelPiece>(_tunnelPieces);
        var pieceFromGrabBag = grabBag.Grab();
        if (pieceFromGrabBag == null)
        {
            Debug.LogError("Unable to choose a random destination for the Bee. Stopping Movement");
        }

        _lastTunnelPosition = _lastTunnelPiece.transform.position - new Vector3(_lastTunnelPiece.GetDistance(),0.0f,0.0f)
                    - new Vector3(pieceFromGrabBag.GetDistance(),0.0f,0.0f);
         
        _lastTunnelPiece = Instantiate(pieceFromGrabBag, _lastTunnelPosition, Quaternion.identity);
    }

    public void SetIsPieceDestroyed(bool isdestroyed) 
    {
        IsPieceDestroyed = isdestroyed;
    }
}
