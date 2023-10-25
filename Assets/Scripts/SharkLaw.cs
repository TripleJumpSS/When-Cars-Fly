using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkLaw : MonoBehaviour
{
    public GameObject player; //The Player character.
    public float distance; //Distance from the player character's position.
    public float speed; //How quickly the shark copies the player's x/y position.
    public Vector3 Pos; //The player's x position, y position, and distance is the z position.
    public bool TrackPlayer; //Whether or not the shark should copy the player's x/y position. Triggered by the SharkToggleTracking script.
    public GameObject SharkManager;

    void Update()
    {

        if(TrackPlayer == true)
        {
            //Sets Pos as the player's x position, y position, and distance is the z position every frame.
            Pos = new Vector3(distance, player.transform.position.y, player.transform.position.z);
            
            //Transitions smoothly between the shark's current position and the Pos position. 
            transform.position = Vector3.Lerp(transform.position, Pos, speed * Time.deltaTime);
        }

        else
        {
            //Sets Pos as the player's x position, y position, and distance is the z position every frame.
            Pos = new Vector3(distance, transform.position.y, transform.position.z);
            
            //Transitions smoothly between the shark's current position and the Pos position. 
            transform.position = Vector3.Lerp(transform.position, Pos, speed * Time.deltaTime);
        }
    }

    public void Track(){TrackPlayer = true;}
    public void StopTrack(){TrackPlayer = false;} //NextShark.SetActive(true);}
    public void Close(){distance = 23;}
    public void Far(){distance = 35;}
    
}
