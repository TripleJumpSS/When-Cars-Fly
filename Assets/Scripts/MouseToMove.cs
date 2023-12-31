using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MouseToMove : MonoBehaviour
{


 
//Define the camera that we will use
//Don't forget to set this to the camera in your game
public GameObject mouseposition; public GameObject boom;
public Camera screenCamera;
public GameObject invincibleparticles;

 
//The desired distance from the camera to the object
public float zDistance; public float StarterZ; public float lateralspeed;

public string State; public float strength; 
public float invincibilityframestimer; public bool iFrames; public bool Invinciblestar;

void Start(){FrontFacing3D();}

void invincibilitystar(){iFrames = true; Invinciblestar = true;
    invincibilityframestimer = 10; transform.GetChild(0).gameObject.SendMessage("RainbowOutline");}

void Update () 
{
    var mousePos = Input.mousePosition;

    if(invincibilityframestimer > 0 && iFrames)
    {invincibilityframestimer -= 1 * Time.deltaTime;}

    else if(invincibilityframestimer <= 0 && iFrames)
    {iFrames = false; transform.GetChild(0).gameObject.SendMessage("RainbowOff"); Invinciblestar = false;}
   
    // Set the position of the transform to a position defined by the mouse
    // which is zDistance units away from the screenCamera
    if(State == "FrontFacing3D"||State == "BackFacing3D")
    {
    Vector3 pos = new Vector3(zDistance, mouseposition.transform.position.y, mouseposition.transform.position.z);
    this.transform.position = Vector3.Lerp(transform.position, pos, lateralspeed * Time.deltaTime);
    }
    else if(State == "SideScroll2D")
    {
    Vector3 pos2 = new Vector3(mouseposition.transform.position.x, mouseposition.transform.position.y, zDistance);
    this.transform.position = Vector3.Lerp(transform.position, pos2, lateralspeed * Time.deltaTime);
    }
    else
    {
    Vector3 pos2 = new Vector3(mouseposition.transform.position.x, zDistance, mouseposition.transform.position.z);
    this.transform.position = Vector3.Lerp(transform.position, pos2, lateralspeed * Time.deltaTime);
    }
    /*
    Quaternion targetRotation = Quaternion.LookRotation (mousepositioncube.transform.position - transform.position);
    float str = Mathf.Min (strength * Time.deltaTime, 1);
    transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, str);
    */
    if(Input.GetKeyDown(KeyCode.Alpha1)){FrontFacing3D();}
    if(Input.GetKeyDown(KeyCode.Alpha2)){BackFacing3D();}
    if(Input.GetKeyDown(KeyCode.Alpha3)){TopDown2D();}
    if(Input.GetKeyDown(KeyCode.Alpha4)){SideScroll2D();}

}

public IEnumerator HIT()
{
    if(!iFrames)
    boom.SetActive(true);
    iFrames = true;
    invincibilityframestimer = 2;
    StarterZ = zDistance;
    zDistance += 4;
    transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Recoiling", true);
    yield return new WaitForSeconds(0.5f);
    transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Recoiling", false);
    yield return new WaitForSeconds(0.5f);
    zDistance -= 1; yield return new WaitForSeconds(0.2f);
    zDistance -= 1; yield return new WaitForSeconds(0.2f);
    zDistance -= 1; yield return new WaitForSeconds(0.2f);
    zDistance -= 1;
    boom.SetActive(false);
    
}

public IEnumerator BOOST()
{
    transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Boosting", true);
    StarterZ = zDistance;
    zDistance -= 4;
    yield return new WaitForSeconds(0.1f);
    transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Boosting", false);
    yield return new WaitForSeconds(0.4f);
    zDistance += 1; yield return new WaitForSeconds(0.1f);
    zDistance += 1; yield return new WaitForSeconds(0.1f);
    zDistance += 1; yield return new WaitForSeconds(0.1f);
    zDistance += 1;
    
}


public void FrontFacing3D()
{
    State = "FrontFacing3D";
    zDistance = 10;
    //screenCamera.transform.position = new Vector3(18.5f, -1, -0.1f);
    //screenCamera.transform.rotation = Quaternion.Euler(-12, -90, 0);
    screenCamera.GetComponent<Animator>().SetBool("FaceBack", false);
    screenCamera.GetComponent<Animator>().SetBool("FaceFront", true);
    
    
}

public void BackFacing3D()
{
    State = "BackFacing3D";
    zDistance = 15;
    //screenCamera.transform.position = new Vector3(4.2f, 2, 0.1f);
    //screenCamera.transform.rotation = Quaternion.Euler(-21, 90, 0);
    screenCamera.GetComponent<Animator>().SetBool("FaceFront", false);
    screenCamera.GetComponent<Animator>().SetBool("FaceBack", true);
    
    
}

public void TopDown2D()
{
    State = "TopDown2D";
    zDistance = -4;
    screenCamera.transform.position = new Vector3(11.5f, 4.5f, 1.2f);
    screenCamera.transform.rotation = Quaternion.Euler(90f, 180, 0);
    
}

public void SideScroll2D()
{
    State = "SideScroll2D";
    zDistance = -5;
    screenCamera.transform.position = new Vector3(11.5f, -1, 5.1f);
    screenCamera.transform.rotation = Quaternion.Euler(-21, 180, 0);
    
}

public void FixZPositionOnTransition()
{
    transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Recoiling", false);
    transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Boosting", false);
    StopCoroutine("BOOST"); StopCoroutine("HIT");
    
    switch (State)
    {
        case "FrontFacing3D":  FrontFacing3D(); break;
        case "BackFacing3D": BackFacing3D(); break;
        case "TopDown2D": TopDown2D(); break;
        case "SideScroll2D": SideScroll2D(); break;
        
        default: print("Don't panic but INVALID STATE FOR THE FIXZPOSITION ON THE PLAYER MOVEMENT SCRIPT! EVERYONE STAY CALMMMMMMMMMMMMMMMMMMMMMM!!!!"); break; 
    }
}

}