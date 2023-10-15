using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeSpeedOnEntry : MonoBehaviour
{
    [Header("(A Minus Number will Speed Down)")]
    public float ChangeSpeedByHowMuch;
    public GameObject TunnelManager;  public GameObject Player; 
    public bool HaveIBeenUsedYet; //Stops the player from triggering the same object multiple times.
    public bool DestroyOnContact; 
    public GameObject GameManager;
    
    void Awake()
    {TunnelManager = GameObject.Find("TunnelManager"); HaveIBeenUsedYet = false;
    //This allows the prefab to find the TunnelManager in the scene using it's name in the inspector.
    //^ this means that renaming the TunnelManager will break this code.

    GameManager = GameObject.Find("Game Manager"); Player = GameObject.Find("Player"); 
    bool ChasingInProgress = GameManager.GetComponent<SharkProximity>().Chased;
    if (ChasingInProgress == true) {Destroy(this.gameObject);} 

    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && HaveIBeenUsedYet == false)
        {
            HaveIBeenUsedYet = true;
            TunnelManager.GetComponent<TunnelManager>().ChangeSpeed(ChangeSpeedByHowMuch);

            if(DestroyOnContact == true)
            {Destroy(this.gameObject); Player.SendMessage("BOOST");}
            else
            {Player.SendMessage("HIT");}
        }
    }



}
