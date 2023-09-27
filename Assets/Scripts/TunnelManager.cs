using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class TunnelManager : MonoBehaviour
{
    [SerializeField] Transform _startingPoint;
    [SerializeField] Transform _endingPoint;
    [SerializeField] TunnelPiece[] _tunnelPieces;
    private void Awake()
    {
    }
    void OnEnable()
    {
        StartCoroutine(StartMovement());
        
    }
    IEnumerator StartMovement() 
    {
        GrabBag<TunnelPiece> grabBag = new GrabBag<TunnelPiece>(_tunnelPieces);

        while (true)
        {
            var piece = grabBag.Grab();
            if (piece == null)
            {
                Debug.LogError("Unable to choose a random destination for the Bee. Stopping Movement");
                yield break;
            }
            Instantiate(piece);
            piece.Launch(_startingPoint.position, _endingPoint.position);

            
            yield return new WaitForSeconds(5.0f);
        }
    }
    void Fire()
    {
        TunnelPiece tunnelPiece = PoolManager.Instance.GetTunnelPiece();
        tunnelPiece.Launch( _startingPoint.position, _endingPoint.position);
    }
}
