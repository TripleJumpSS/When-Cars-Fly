using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarDiskMovement : MonoBehaviour
{
    public float playerspeed; public float speedmultiplier;
    public float distancetravelled; public float distancerounded; 
    public TMP_Text DistanceText; public TMP_Text SpeedText;
    public int num;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * playerspeed * speedmultiplier * Time.deltaTime);
        distancetravelled += 0.1f * speedmultiplier * Time.deltaTime;
        DistanceText.text = distancetravelled.ToString("F2") + "km";
        SpeedText.text = "x" + speedmultiplier.ToString("F1");
        distancerounded = Mathf.Floor(distancetravelled);


        if(distancerounded > 0 && distancerounded % num == 0)
        {
            print("yay");
            speedmultiplier += 0.1f;
            num += 1;
        }
        
    }
}
