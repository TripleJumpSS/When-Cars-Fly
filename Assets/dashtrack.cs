using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashtrack : MonoBehaviour
{
    public bool TargetTracking;
    public Transform player;
    public Transform shark;
    public GameObject image;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TargetTracking){transform.position = new Vector3(15, shark.position.y, player.position.z);}
        
    }

    public void targettrackon(){TargetTracking = true;}
    public void targettrackoff(){TargetTracking = false;}
    public void displayoff(){image.SetActive(false);}
    public void displayon(){image.SetActive(true);}
}
