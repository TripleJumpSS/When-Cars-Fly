using System.Collections.Generic;
using UnityEngine;


public class TunnelManager : MonoBehaviour
{
    [SerializeField] Transform _startingPoint;
    [SerializeField] GameObject _endWall;
    [SerializeField] TunnelPiece[] _tunnelPieces;
    [SerializeField] TunnelPiece _lastTunnelPiece;
    [SerializeField] float _speed = 2.0f;
    [SerializeField] List<TunnelPiece> _tunnelPiecesList = new List<TunnelPiece>();
    bool IsPieceDestroyed = false;
    public Vector3 _lastTunnelPosition = Vector3.zero;

    void Update()
    {
        if (IsPieceDestroyed == true)
        {
            CreateNewPiece();
            RemovePieceFromList();  
        }
    }

    private void RemovePieceFromList()
    {
        _tunnelPiecesList.RemoveAt(0);
        IsPieceDestroyed = false;
    }

    void OnDrawGizmos() 
    {
        // ======== FOR DEVELOPMENT ============
        //draws red line between te startingPoint and endWall
        Vector3 start = _startingPoint.position;
        Vector3 end = _endWall.transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(start, end);
    }

    void CreateNewPiece()
    {
        GrabBag<TunnelPiece> grabBag = new GrabBag<TunnelPiece>(_tunnelPieces);
        //grab a tunnelPice from the grabBag
        var pieceFromGrabBag = grabBag.Grab();
        if (pieceFromGrabBag == null)
        {
            Debug.LogError("Unable to choose a random destination for the Bee. Stopping Movement");
        }
        //add that piece to the List
        _tunnelPiecesList.Add(pieceFromGrabBag);
        //calculate the needed distance between the last and new tunnelPiece
        _lastTunnelPosition = _lastTunnelPiece.transform.position - new Vector3(_lastTunnelPiece.GetDistance(),0.0f,0.0f)
                    - new Vector3(pieceFromGrabBag.GetDistance(),0.0f,0.0f);
         //create new tunnelPiece in scene and set its speed to the TunnelManagers speed
        _lastTunnelPiece = Instantiate(pieceFromGrabBag, _lastTunnelPosition, Quaternion.identity);
        _lastTunnelPiece.SetSpeed(_speed);
    }
    
    void SetSpeedToAll(float speed)
    {
        //set the speed to all tunnelPiece in the list
        foreach (var tunnelPiece in _tunnelPiecesList) 
        {
            tunnelPiece.SetSpeed(speed);
        }
        _speed = speed;
    }

    public void SetIsPieceDestroyed(bool isdestroyed) 
    {
        IsPieceDestroyed = isdestroyed;
    }

    //========== FOR TESTING PURPOSES ======================
    [ContextMenu(nameof(SetSpeedToTwentyFive))]
    void SetSpeedToTwentyFive()
    {
        foreach (var tunnelPiece in _tunnelPiecesList)
        {
            tunnelPiece.SetSpeed(25.0f);
        }
        _speed = 25.0f;
    }
    [ContextMenu(nameof(SetSpeedToFifty))]
    void SetSpeedToFifty() 
    {
        foreach (var tunnelPiece in _tunnelPiecesList)
        {
            tunnelPiece.SetSpeed(50.0f);
        }
        _speed = 50.0f;
    }

}
