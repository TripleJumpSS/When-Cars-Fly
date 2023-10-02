using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeedOnEntry : MonoBehaviour
{
    [Header("Bool On = Decreased Speed ///// Bool Off = Increased Speed")]
    public bool SpeedDown;
    public GameObject TunnelManager; 
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(SpeedDown == true){TunnelManager.SendMessage("DownSpeedBy10");}
            else{TunnelManager.SendMessage("UpSpeedBy5");}
        }
    }
}
