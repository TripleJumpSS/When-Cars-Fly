using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{


 
//Define the camera that we will use
//Don't forget to set this to the camera in your game
public Camera screenCamera;

 
//The desired distance from the camera to the object
public float zDistance;



void Update () 
{
    var mousePos = Input.mousePosition;
   
    // Set the position of the transform to a position defined by the mouse
    // which is zDistance units away from the screenCamera
    this.transform.position = screenCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zDistance));

}


}