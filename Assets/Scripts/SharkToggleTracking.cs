using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkToggleTracking : MonoBehaviour
{
    public GameObject SharkParent;
    public void TrackingOn()
    {SharkParent.SendMessage("Track");}

    public void TrackingOff()
    {SharkParent.SendMessage("StopTrack");}
}
