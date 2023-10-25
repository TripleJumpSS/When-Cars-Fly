using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkToggleTracking : MonoBehaviour
{
    public GameObject SharkParent;
    public GameObject SharkManager;
    public GameObject DeathBall;
    public GameObject Player;
    public void TrackingOn()
    {SharkParent.SendMessage("Track");}
    public void TrackingTrick()
    {SharkParent.SendMessage("TrickTrack");}
    public void CloseIn()
    {SharkParent.SendMessage("Close");}
    public void BackOff()
    {SharkParent.SendMessage("Far");}
    
    public void EndOfAttack()
    {SharkManager.GetComponent<SharkManager>().didattack();}


    public void TrackingOff()
    {SharkParent.SendMessage("StopTrack");}

    public void ChaseOff()
    {SharkParent.SendMessage("EndChase");}


    public void RepairPlayerZPosition()
    {Player.SendMessage("FixZPositionOnTransition"); Player.transform.GetChild(0).SendMessage("SeethroughOff");}


    public void KillOn()
    {DeathBall.SendMessage("OpenYourMouth");}
    public void KillOff()
    {DeathBall.SendMessage("ShutYourMouth");}
}
