using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TunnelManager : MonoBehaviour
{
    [SerializeField] Transform _startingPoint;
    [SerializeField] GameObject _endWall;
    [SerializeField] TunnelPiece[] _tunnelPieces;
    [SerializeField] TunnelPiece _lastTunnelPiece;
    [SerializeField] float _speed = 2.0f;
    [SerializeField] List<TunnelPiece> _tunnelPiecesList = new List<TunnelPiece>();
    [SerializeField] TextMeshProUGUI _distanceUI;
    [SerializeField] float _distanceTaken = 0;
    //testing
    [SerializeField] GameObject _distanceMeter;
    Rigidbody _rbDistanceMeter;
    Vector3 _direction = new Vector3(1, 0, 0);

    bool IsPieceDestroyed = false;
    public Vector3 _lastTunnelPosition = Vector3.zero;
    [SerializeField] GameObject _player;

    private void Awake()
    {
        _distanceUI.text = _distanceTaken.ToString("F2");
        _rbDistanceMeter = _distanceMeter.GetComponent<Rigidbody>();
    }
    void OnEnable()
    {
        //StartCoroutine(DistanceCounter());
    }
    void Update()
    {
        _rbDistanceMeter.velocity = _direction * _speed;
        _distanceUI.text = GetDistancePlayerTaken().ToString("F2");
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
    IEnumerator DistanceCounter() 
    {
        while (true)
        {
            _distanceTaken += _speed;
            _distanceUI.text = _distanceTaken.ToString("F2");
            yield return new WaitForSeconds(1.0f);
        }

    }
    float GetDistancePlayerTaken() 
    {
        float distance = _distanceMeter.transform.position.x - _player.transform.position.x;

        return distance;
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
