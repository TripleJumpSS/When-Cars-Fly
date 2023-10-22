using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableoutlineseethrough : MonoBehaviour
{
    public bool disableOutline;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !disableOutline)
        {
            other.transform.GetChild(0).gameObject.SendMessage("SeethroughDebris");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" && disableOutline)
        {
            other.transform.GetChild(0).gameObject.SendMessage("SeethroughOff");
        }
    }
}
