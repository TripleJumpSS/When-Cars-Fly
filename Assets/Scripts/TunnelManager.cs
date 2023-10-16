using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TunnelManager : MonoBehaviour
{
    [SerializeField] Transform _startingPoint;
    [SerializeField] GameObject _endWall;
    [SerializeField] TunnelPiece[] _stageOnePieces;
    [SerializeField] TunnelPiece[] _stageTwoPieces;
    [SerializeField] TunnelPiece[] _stageThreePieces;
    [SerializeField] TunnelPiece[] _stageFourPieces;
    [SerializeField] TunnelPiece _lastTunnelPiece;
    [SerializeField] List<TunnelPiece> _mainTunnelList = new List<TunnelPiece>();

    [SerializeField] TextMeshProUGUI _distanceUI;
    [SerializeField] float _distanceTaken = 0;
    [SerializeField] GameObject _distanceMeter;

    GrabBag<TunnelPiece> _tunnelPieceGrabBag;

    //testing
    Rigidbody _rbDistanceMeter;
    Vector3 _direction = new Vector3(1, 0, 0);
    bool IsPieceDestroyed = false;

    public float _speed = 2.0f; 
    public Vector3 _lastTunnelPosition = Vector3.zero;
    public Slider _SpeedSlider;

    [SerializeField] GameObject _player;
    [SerializeField] GameObject _plane;
    [SerializeField] GameObject _bubbles; 
    [SerializeField] GameObject playerspeedparticles;
    [SerializeField] GameObject gamemanager;

    public float MaxSpeedCap; public float MinSpeedCap;

    bool _isNewStage = false;
    int _stageTwoPoint =      500;
    int _stageThreePoint =    1000;
    int _stageFourPoint =     1500;

    void Awake()
    {
        _distanceUI.text =  _distanceTaken.ToString("F2");
        _rbDistanceMeter = _distanceMeter.GetComponent<Rigidbody>();
        SetSpeedToTwentyFive();
        VisualsThatChangeBasedOnSpeed();
        playerspeedparticles.GetComponent<ParticleSystem>().emissionRate = 0;
        _tunnelPieceGrabBag = new GrabBag<TunnelPiece>(_stageOnePieces);
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

        if (IsNewStage())
        {
            CheckAndSetupStage(_stageTwoPoint, _stageTwoPieces);        //STAGE TWO
            CheckAndSetupStage(_stageThreePoint, _stageThreePieces);    //STAGE THREE
            CheckAndSetupStage(_stageFourPoint, _stageFourPieces);      //STAGE FOUR
        }

        //if(Input.GetKeyDown(KeyCode.A)){UpSpeed(5);}
        //if(Input.GetKeyDown(KeyCode.S)){DownSpeed(10);}

        CheckAndSetSpeedCaps();
    }

    void CheckAndSetSpeedCaps()
    {
        if (_speed > MaxSpeedCap)
        {
            _speed = MaxSpeedCap;
            foreach (var tunnelPiece in _mainTunnelList)
                tunnelPiece.SetSpeed(MaxSpeedCap);
        }

        if (_speed < MinSpeedCap)
        {
            _speed = MinSpeedCap;
            foreach (var tunnelPiece in _mainTunnelList)
                tunnelPiece.SetSpeed(MinSpeedCap);
        }
    }

    void RemovePieceFromList()
    {
        _mainTunnelList.RemoveAt(0);
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

        //grab a tunnelPice from the grabBag
        var pieceFromGrabBag = _tunnelPieceGrabBag.Grab();
        if (pieceFromGrabBag == null)
        {
            Debug.LogError("Unable to choose a random destination for the Bee. Stopping Movement");
        }
        //add that piece to the List
        _mainTunnelList.Add(pieceFromGrabBag);
        //calculate the needed distance between the last and new tunnelPiece
        _lastTunnelPosition = _lastTunnelPiece.transform.position - new Vector3(_lastTunnelPiece.GetDistance(), 0.0f, 0.0f)
                    - new Vector3(pieceFromGrabBag.GetDistance(), 0.0f, 0.0f);
        //create new tunnelPiece in scene and set its speed to the TunnelManagers speed
        _lastTunnelPiece = Instantiate(pieceFromGrabBag, _lastTunnelPosition, Quaternion.identity);
        _lastTunnelPiece.SetSpeed(_speed);


    }
    void CheckAndSetupStage(float stage, TunnelPiece[] list)
    {
        if (GetDistancePlayerTaken() > stage)
            _tunnelPieceGrabBag = new GrabBag<TunnelPiece>(list);
    }
    bool IsNewStage()
    {
        int distance = (int)GetDistancePlayerTaken();
        if (distance == _stageTwoPoint || distance == _stageThreePoint || distance == _stageFourPoint)
            _isNewStage = true;
        else
            _isNewStage = false;

        return _isNewStage;
    }
    float GetDistancePlayerTaken() 
    {
        float distance = _distanceMeter.transform.position.x - _player.transform.position.x;

        return distance;
    }
    void SetSpeedToAll(float speed)
    {
        //set the speed to all tunnelPiece in the list
        foreach (var tunnelPiece in _mainTunnelList) 
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
        foreach (var tunnelPiece in _mainTunnelList)
        {
            tunnelPiece.SetSpeed(25.0f);
        }
        _speed = 25.0f;
        VisualsThatChangeBasedOnSpeed();
    }
    [ContextMenu(nameof(SetSpeedToFifty))]
    void SetSpeedToFifty() 
    {
        foreach (var tunnelPiece in _mainTunnelList)
        {
            tunnelPiece.SetSpeed(50.0f);
        }
        _speed = 50.0f;
        VisualsThatChangeBasedOnSpeed();
    }

    public void ChangeSpeed(float changeBy)
    {
        foreach (var tunnelPiece in _mainTunnelList)
        {
            tunnelPiece.UpSpeed(changeBy);
        }
        _speed += changeBy;
        VisualsThatChangeBasedOnSpeed();
    }

    public void SetSpeedToYellow(float Yellow) 
    {
        foreach (var tunnelPiece in _mainTunnelList)
        {
            tunnelPiece.SetSpeed(Yellow);
        }
        _speed = Yellow;
        VisualsThatChangeBasedOnSpeed();
    }

    public void VisualsThatChangeBasedOnSpeed()
    {
        _plane.GetComponent<ScrollingTexture>().ScrollX = _speed / 10;

        float yellow = gamemanager.GetComponent<SharkProximity>().Yellow;

        if(_speed < yellow)
            _bubbles.GetComponent<ParticleSystem>().emissionRate = 0;
        else
            _bubbles.GetComponent<ParticleSystem>().emissionRate = _speed / 1.5f;

        float grellow = gamemanager.GetComponent<SharkProximity>().Grellow;

        if(_speed < grellow)
            playerspeedparticles.GetComponent<ParticleSystem>().emissionRate = 0;
        else
            playerspeedparticles.GetComponent<ParticleSystem>().emissionRate = _speed;


        _player.transform.GetChild(0).gameObject.GetComponent<Animator>().speed = _speed / 20;
        
    }

}
