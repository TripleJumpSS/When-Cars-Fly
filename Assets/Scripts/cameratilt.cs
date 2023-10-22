using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameratilt : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.y < 0)
        transform.localPosition = new Vector3(player.position.x / 2, 0, 0);
        else
        transform.localPosition = new Vector3(player.position.x / 2, player.position.y / 2, 0);
    }
}
