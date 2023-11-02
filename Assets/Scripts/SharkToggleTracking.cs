using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkToggleTracking : MonoBehaviour
{
    public GameObject SharkParent;
    public GameObject SharkManager;
    public GameObject DeathBall;
    public GameObject Player; public GameObject target;
    public bool IAmSharkOne; public bool IAmABackShark;
    public void TrackingOn()
    {SharkParent.SendMessage("Track");}
    public void CloseIn()
    {SharkParent.SendMessage("Close");}
    public void BackOff()
    {SharkParent.SendMessage("Far"); if(IAmABackShark){target.SendMessage("targettrackon");}}
    
    public void EndOfAttack()
    {SharkManager.GetComponent<SharkManager>().didattack();}


    public void TrackingOff()
    {SharkParent.SendMessage("StopTrack"); if(IAmABackShark){target.SendMessage("targettrackoff");}}

    public void ChaseOff()
    {SharkParent.SendMessage("EndChase");}


    public void RepairPlayerZPosition()
    {Player.SendMessage("FixZPositionOnTransition"); Player.transform.GetChild(0).SendMessage("SeethroughOff");}


    public void KillOn()
    {DeathBall.SendMessage("OpenYourMouth"); if(IAmSharkOne){SendMessageUpwards("LevelUp");}}
    public void KillOff()
    {DeathBall.SendMessage("ShutYourMouth");}
}
