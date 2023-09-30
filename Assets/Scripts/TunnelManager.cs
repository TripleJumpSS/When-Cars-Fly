using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class TunnelManager : MonoBehaviour
{
    [SerializeField] Transform _startingPoint;
    [SerializeField] GameObject _endWall;
    [SerializeField] GameObject _pullingPoint;
    [SerializeField] TunnelPiece[] _tunnelPieces;
    [SerializeField] float _speed = 2.0f;
    [SerializeField] List<TunnelPiece> _tunnelList = new List<TunnelPiece>();
    Rigidbody _rb;
    bool IsPieceDestroyed = false;
    Vector3 _direction = new Vector3(1,0,0);
    

    void Awake()
    {
        _rb = _pullingPoint.GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rb.velocity = _direction * _speed;
        if (IsPieceDestroyed == true)
        {
            RemoveFirstPieceFromList();
            CreateNewPiece();
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
        int newPieceCount = _tunnelList.Count- 1;
        Vector3 lastPieceEndPoint = _tunnelList[newPieceCount].transform.position;

        var pieceFromGrabBag = grabBag.Grab();
        if (pieceFromGrabBag == null)
        {
            Debug.LogError("Unable to choose a random destination for the Bee. Stopping Movement");
        }
        _tunnelList.Add(pieceFromGrabBag);

         lastPieceEndPoint.x -= _tunnelList[newPieceCount].GetDistance();

        Instantiate(_tunnelList[newPieceCount], lastPieceEndPoint, Quaternion.identity);
        Debug.Log($"" + lastPieceEndPoint);
    }

    void RemoveFirstPieceFromList()
    {
        _tunnelList.Remove(_tunnelList[0]);
        IsPieceDestroyed = false;
    }

    public void SetIsPieceDestroyed(bool isdestroyed) 
    {
        IsPieceDestroyed = isdestroyed;
    }
}
