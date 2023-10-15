using System.Collections;
using System.Collections.Generic;
using TMPro;
//using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class TunnelManager : MonoBehaviour
{
    [SerializeField] Transform _startingPoint;
    [SerializeField] GameObject _endWall;
    [SerializeField] TunnelPiece[] _tunnelPieces;
    [SerializeField] TunnelPiece _lastTunnelPiece;
    public float _speed = 2.0f; 
    [SerializeField] List<TunnelPiece> _tunnelPiecesList = new List<TunnelPiece>();
    [SerializeField] TextMeshProUGUI _distanceUI;
    public Slider _SpeedSlider;
    [SerializeField] float _distanceTaken = 0;
    //testing
    [SerializeField] GameObject _distanceMeter;
    Rigidbody _rbDistanceMeter;
    Vector3 _direction = new Vector3(1, 0, 0);

    bool IsPieceDestroyed = false;
    public Vector3 _lastTunnelPosition = Vector3.zero;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _plane;
    [SerializeField] GameObject _bubbles; [SerializeField] GameObject playerspeedparticles;
    [SerializeField] GameObject gamemanager;

    public float MaxSpeedCap; public float MinSpeedCap;

    private void Awake()
    {
        _distanceUI.text =  _distanceTaken.ToString("F2");
        _rbDistanceMeter = _distanceMeter.GetComponent<Rigidbody>();
        SetSpeedToTwentyFive();
        VisualsThatChangeBasedOnSpeed();
        playerspeedparticles.GetComponent<ParticleSystem>().emissionRate = 0;
    }
    void OnEnable()
    {
        //StartCoroutine(DistanceCounter());
    }
    void Update()
    {
        _rbDistanceMeter.velocity = _direction * _speed;
        _distanceUI.text = "Points: " + GetDistancePlayerTaken().ToString("F2");
        _SpeedSlider.value = _speed;
        if (IsPieceDestroyed == true)
        {
            CreateNewPiece();
            RemovePieceFromList();  
        }

        //if(Input.GetKeyDown(KeyCode.A)){UpSpeed(5);}
        //if(Input.GetKeyDown(KeyCode.S)){DownSpeed(10);}

        if(_speed > MaxSpeedCap){_speed = MaxSpeedCap; 
        foreach (var tunnelPiece in _tunnelPiecesList)
        {tunnelPiece.SetSpeed(MaxSpeedCap);}}

        if(_speed < MinSpeedCap){_speed = MinSpeedCap;
        foreach (var tunnelPiece in _tunnelPiecesList)
        {tunnelPiece.SetSpeed(MinSpeedCap);}}
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
        VisualsThatChangeBasedOnSpeed();
    }
    [ContextMenu(nameof(SetSpeedToFifty))]
    void SetSpeedToFifty() 
    {
        foreach (var tunnelPiece in _tunnelPiecesList)
        {
            tunnelPiece.SetSpeed(50.0f);
        }
        _speed = 50.0f;
        VisualsThatChangeBasedOnSpeed();
    }

    public void ChangeSpeed(float changeby)
    {
        foreach (var tunnelPiece in _tunnelPiecesList)
        {
            tunnelPiece.UpSpeed(changeby);
        }
        _speed += changeby;
        VisualsThatChangeBasedOnSpeed();
    }

    public void SetSpeedToYellow(float Yellow) 
    {
        foreach (var tunnelPiece in _tunnelPiecesList)
        {
            tunnelPiece.SetSpeed(Yellow);
        }
        _speed = Yellow;
        VisualsThatChangeBasedOnSpeed();
    }

    public void VisualsThatChangeBasedOnSpeed()
    {
        //_plane;
        _plane.GetComponent<ScrollingTexture>().ScrollX = _speed / 10;

        float yellow = gamemanager.GetComponent<SharkProximity>().Yellow;
        if(_speed < yellow){_bubbles.GetComponent<ParticleSystem>().emissionRate = 0;}
        else{_bubbles.GetComponent<ParticleSystem>().emissionRate = _speed / 1.5f;}

        float grellow = gamemanager.GetComponent<SharkProximity>().Grellow;
        if(_speed < grellow){playerspeedparticles.GetComponent<ParticleSystem>().emissionRate = 0;}
        else{playerspeedparticles.GetComponent<ParticleSystem>().emissionRate = _speed;}


        _player.transform.GetChild(0).gameObject.GetComponent<Animator>().speed = _speed / 20;
        
    }

}
