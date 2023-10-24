using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideSharkLaw : MonoBehaviour
{
    public GameObject player; //The Player character.
    public float distance; //Distance from the player character's position.
    public float speed; //How quickly the shark copies the player's x/y position.
    public Vector3 Pos; //The player's x position, y position, and distance is the z position.
    public bool TrackPlayer; //Whether or not the shark should copy the player's x/y position. Triggered by the SharkToggleTracking script.
    public GameObject GameManager;
    public GameObject Shark;
    public float Attacks;

    void Update()
    {
        if(Attacks > 2)
        {
           Attacks = 0; Shark.GetComponent<Animator>().SetBool("FightIsOver", true);
        }

        if(TrackPlayer == true)
        {
            //Sets Pos as the player's x position, y position, and distance is the z position every frame.
            Pos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            
            //Transitions smoothly between the shark's current position and the Pos position. 
            //transform.position = Vector3.Lerp(transform.position, Pos, speed * Time.deltaTime);
            transform.position = Pos;
        }

        else
        {
            
        }
    }

    public void Track(){TrackPlayer = true;}
    public void StopTrack(){TrackPlayer = false;}
    public void Close(){distance = 23;}
    public void Far(){distance = 35;}
    public void AttackOver(){Attacks += 1;}
    public void EndChase(){Attacks = 0; GameManager.GetComponent<SharkProximity>().SurvivedTheChase(); Shark.GetComponent<Animator>().SetBool("FightIsOver", false);}
}