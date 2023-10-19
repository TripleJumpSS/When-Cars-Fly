using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelicanMovement : MonoBehaviour
{
    public float Force;
    public bool MoveRight;

    void Awake()
    {
        if(MoveRight){transform.rotation = Quaternion.Euler(0,0,0);}
        else{transform.rotation = Quaternion.Euler(0,180,0);}
    }
    void Update()
    {
        if (MoveRight)
        {
            transform.localPosition += Vector3.forward * Force * Time.deltaTime;
        }
        else
        {
            transform.localPosition += Vector3.back * Force * Time.deltaTime;
        }
    }
}
