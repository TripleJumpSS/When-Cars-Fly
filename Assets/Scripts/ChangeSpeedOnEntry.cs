using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeedOnEntry : MonoBehaviour
{
    [Header("(A Minus Number will Speed Down)")]
    public float ChangeSpeedByHowMuch;
    public GameObject TunnelManager; 
    public bool HaveIBeenUsedYet; //Stops the player from triggering the same object multiple times.
    
    void Awake()
    {TunnelManager = GameObject.Find("TunnelManager"); HaveIBeenUsedYet = false;}
    //This allows the prefab to find the TunnelManager in the scene using it's name in the inspector.
    //^ this means that renaming the TunnelManager will break this code.


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && HaveIBeenUsedYet == false)
        {
            HaveIBeenUsedYet = true;
            TunnelManager.SendMessage("ChangeSpeed", ChangeSpeedByHowMuch);
        }
    }
}
