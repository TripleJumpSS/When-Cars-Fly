using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MousetoMove : MonoBehaviour
{


 
//Define the camera that we will use
//Don't forget to set this to the camera in your game
public Camera screenCamera;

 
//The desired distance from the camera to the object
public float zDistance;

public bool fly;
//^^if this is true, the player has Y-axis movement. Otherwise they're locked to the X-axis. 

public bool Grounded;

public float SP;
public Slider SPGauge;


void Update () 
{
    var mousePos = Input.mousePosition;
   
    // Set the position of the transform to a position defined by the mouse
    // which is zDistance units away from the screenCamera
    if(fly)
    {this.transform.position = screenCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zDistance));}

    // same thing, except that it only alters the x axis position.
    else
    {this.transform.position = screenCamera.ScreenToWorldPoint(new Vector3(mousePos.x, 530, zDistance));}

    if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1))
    {
        if(fly){fly = false;}
        else{fly = true;}
    }

    if(fly && Grounded == true){SP += 1 * Time.deltaTime; SPGauge.value = SP;}
    else if(fly && Grounded == false){SP -= 1.3f * Time.deltaTime; SPGauge.value = SP;}

    if(SP > 10){SP = 10;}
    if(SP < 0){SP = 0;}


}

public void OnCollisionEnter(Collision collision)
    {if(collision.gameObject.CompareTag("Road")){Grounded = true;}}

public void OnCollisionExit(Collision collision)
    {if(collision.gameObject.CompareTag("Road")){Grounded = false;}}


}
