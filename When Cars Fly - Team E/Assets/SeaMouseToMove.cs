using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SeaMouseToMove : MonoBehaviour
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
    screenCamera.transform.position = new Vector3(35, 2, -5);
    screenCamera.transform.rotation = Quaternion.Euler(-15, 0, 0);
    
}

public void BackFacing3D()
{
    State = "BackFacing3D";
    zDistance = 7;
    screenCamera.transform.position = new Vector3(35, 7, 10);
    screenCamera.transform.rotation = Quaternion.Euler(15, 180, 0);
    
}

public void TopDown2D()
{
    State = "TopDown2D";
    zDistance = 11;
    screenCamera.transform.position = new Vector3(35, 5, 20);
    screenCamera.transform.rotation = Quaternion.Euler(90, 0, -180);
    
}

public void SideScroll2D()
{
    State = "SideScroll2D";
    zDistance = 13;
    screenCamera.transform.position = new Vector3(44, 4, 25);
    screenCamera.transform.rotation = Quaternion.Euler(0, -90, 0);
    
}

}