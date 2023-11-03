//using System.Collections;
//using System.Collections.Generic;
//using Microsoft.Unity.VisualStudio.Editor;
//using Unity.Android.Types;
using UnityEngine;

public class targettrack : MonoBehaviour
{
    public bool TargetTracking;
    public GameObject image;
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TargetTracking){transform.position = new Vector3(15, player.position.y, player.position.z);}
        
    }

    public void targettrackon(){TargetTracking = true;}
    public void targettrackoff(){TargetTracking = false;}
    public void displayoff(){image.SetActive(false);}
    public void displayon(){image.SetActive(true);}
}
