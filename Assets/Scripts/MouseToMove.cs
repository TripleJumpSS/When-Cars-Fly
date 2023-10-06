using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MouseToMove : MonoBehaviour
{


 
//Define the camera that we will use
//Don't forget to set this to the camera in your game
public Camera screenCamera;

 
//The desired distance from the camera to the object
public float zDistance;

public string State;


void Start(){FrontFacing3D();}

void Update () 
{
    var mousePos = Input.mousePosition;
   
    // Set the position of the transform to a position defined by the mouse
    // which is zDistance units away from the screenCamera
    this.transform.position = screenCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zDistance));

    if(Input.GetKeyDown(KeyCode.Alpha1)){FrontFacing3D();}
    if(Input.GetKeyDown(KeyCode.Alpha2)){BackFacing3D();}
    if(Input.GetKeyDown(KeyCode.Alpha3)){TopDown2D();}
    if(Input.GetKeyDown(KeyCode.Alpha4)){SideScroll2D();}

}

public void FrontFacing3D()
{
    State = "FrontFacing3D";
    zDistance = 7;
    screenCamera.transform.position = new Vector3(18.5f, -1, -0.1f);
    screenCamera.transform.rotation = Quaternion.Euler(-12, -90, 0);
    
}

public void BackFacing3D()
{
    State = "BackFacing3D";
    zDistance = 7;
    screenCamera.transform.position = new Vector3(4.2f, 2, 0.1f);
    screenCamera.transform.rotation = Quaternion.Euler(-21, 90, 0);
    
}

public void TopDown2D()
{
    State = "TopDown2D";
    zDistance = 7;
    screenCamera.transform.position = new Vector3(11.5f, 4.5f, 1.2f);
    screenCamera.transform.rotation = Quaternion.Euler(67.5f, 180, 0);
    
}

public void SideScroll2D()
{
    State = "SideScroll2D";
    zDistance = 8;
    screenCamera.transform.position = new Vector3(11.5f, -1, 5.1f);
    screenCamera.transform.rotation = Quaternion.Euler(-21, 180, 0);
    
}

}