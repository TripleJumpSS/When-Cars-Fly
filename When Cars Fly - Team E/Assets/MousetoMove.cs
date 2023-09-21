using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousetoMove : MonoBehaviour
{


 
//Define the camera that we will use
//Don't forget to set this to the camera in your game
public Camera screenCamera;

 
//The desired distance from the camera to the object
float zDistance = 5.0f;

public bool fly;
 


void Update () 
{
    var mousePos = Input.mousePosition;
   
    // Set the position of the transform to a position defined by the mouse
    // which is zDistance units away from the screenCamera
    if(fly)
    {this.transform.position = screenCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zDistance));}

    // same thing, except that it only alters the x axis position.
    else
    {this.transform.position = screenCamera.ScreenToWorldPoint(new Vector3(mousePos.x, 360, zDistance));}

    if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1))
    {
        if(fly){fly = false;}
        else{fly = true;}
    }


}



}
