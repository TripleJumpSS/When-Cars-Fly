using System.Collections;
using UnityEngine;


public class TunnelManager : MonoBehaviour
{
    [SerializeField] Transform _startingPoint;
    [SerializeField] GameObject _endWall;
    [SerializeField] GameObject _pullingPoint;
    [SerializeField] GameObject[] _tunnelPieces;
    [SerializeField] float _speed = 2.0f;
    Rigidbody _rb;
    Vector3 _summonPoint;
    //List<GameObject> _tunnel = new List<GameObject>();
    Vector3 _direction = new Vector3(1,0,0);

    void Awake()
    {
        _rb = _pullingPoint.GetComponent<Rigidbody>();
        _summonPoint = _startingPoint.position + new Vector3 (5,0,0);
    }
    void OnEnable()
    {
        StartCoroutine(StartMovement());
    }
    void Update()
    {
        _rb.velocity = _direction * _speed;

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
    IEnumerator StartMovement() 
    {
        GrabBag<GameObject> grabBag = new GrabBag<GameObject>(_tunnelPieces);

        while (true)
        {

            var pieceFromGrabBag = grabBag.Grab();
            if (pieceFromGrabBag == null)
            {
                Debug.LogError("Unable to choose a random destination for the Bee. Stopping Movement");
                yield break;
            }
            var piece = Instantiate(pieceFromGrabBag);
            piece.transform.parent = _pullingPoint.transform;

            yield return new WaitForSeconds(5.0f);
        }
    }

}
