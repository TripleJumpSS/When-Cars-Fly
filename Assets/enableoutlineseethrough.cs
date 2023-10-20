using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableoutlineseethrough : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.GetChild(0).gameObject.SendMessage("SeethroughDebris");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.GetChild(0).gameObject.SendMessage("SeethroughOff");
        }
    }
}
