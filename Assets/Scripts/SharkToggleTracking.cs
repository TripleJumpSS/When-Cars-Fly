using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkToggleTracking : MonoBehaviour
{
    public GameObject SharkParent;
    public GameObject Player;
    public void TrackingOn()
    {SharkParent.SendMessage("Track");}

    public void TrackingOff()
    {SharkParent.SendMessage("StopTrack");}

    public void ChaseOff()
    {SharkParent.SendMessage("EndChase");}

    public void RepairPlayerZPosition()
    {Player.SendMessage("FixZPositionOnTransition"); }
}
