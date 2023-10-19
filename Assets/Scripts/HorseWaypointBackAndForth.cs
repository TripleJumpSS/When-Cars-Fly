using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseWaypointBackAndForth : MonoBehaviour
{
    public GameObject[] waypoints;
    int current = 0;
    public float speed;
    public float strength;
    float WPradius = 1;
    public bool FacingLeft;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        
        if(FacingLeft){transform.localRotation = Quaternion.Euler(0,0,0);}
        else{transform.localRotation = Quaternion.Euler(0,180,0);}

        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current++;
            FacingLeft = !FacingLeft;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
    }
}
