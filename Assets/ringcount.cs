using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ringcount : MonoBehaviour
{
    public TMP_Text RingCountNumberText;
    public float RingCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotRing()
    {
        RingCount += 1;
        RingCountNumberText.text = RingCount.ToString();
    }
}
