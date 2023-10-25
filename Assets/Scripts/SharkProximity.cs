using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SharkProximity : MonoBehaviour
{
    public float PlayerSpeed; public GameObject TunnelManager; public GameObject SharkManager; public GameObject Player;
    public float DistanceFromEnemy;
    public Slider SharkDistanceUI;
    public float Orange; public float Yellow; public float Grellow; public float Green;
    public string CurrentColour; public Image ColouredBackground;
    public Color cRed; public Color cOrange; public Color cYellow; public Color cGrellow; public Color cGreen;
    public bool Chased; public GameObject Shark;
    public float Exposure; public bool Pinch; public GameObject Blood;
    //public GameObject RedLight;

    void Start()
    {
        Lv2();
        DistanceFromEnemy = 5;
        PlayerSpeed = TunnelManager.GetComponent<TunnelManager>()._speed;
        Shark.SetActive(false);
        Exposure = 1.37f;
        RenderSettings.skybox.SetFloat("_Exposure", Exposure);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSpeed = TunnelManager.GetComponent<TunnelManager>()._speed;

        if(DistanceFromEnemy < 1){Chase();}
        if(DistanceFromEnemy > 10){DistanceFromEnemy = 10;}

        if(PlayerSpeed >= Grellow){TunnelManager.GetComponent<TunnelManager>()._speed -= 0.4f * Time.deltaTime;}
        if(PlayerSpeed >= Green){TunnelManager.GetComponent<TunnelManager>()._speed -= 0.2f * Time.deltaTime;}
        if(PlayerSpeed < Grellow){TunnelManager.GetComponent<TunnelManager>().VisualsThatChangeBasedOnSpeed();}
        if(PlayerSpeed < Yellow){TunnelManager.GetComponent<TunnelManager>()._speed += 0.4f * Time.deltaTime;}
        if(PlayerSpeed < Orange){TunnelManager.GetComponent<TunnelManager>()._speed += 0.2f * Time.deltaTime;}

    if(Chased == false)
    {
        if(PlayerSpeed < Orange)//aka they're in the red.
        {DistanceFromEnemy -= 1f * Time.deltaTime; CurrentColour = "RED"; ColouredBackground.color = cRed; if(Pinch){DistanceFromEnemy += 0.20f * Time.deltaTime;}}
        if(PlayerSpeed >= Orange && PlayerSpeed < Yellow)//aka they're in the orange.
        {DistanceFromEnemy -= 0.75f * Time.deltaTime; CurrentColour = "ORANGE"; ColouredBackground.color = cOrange; if(Pinch){DistanceFromEnemy += 0.05f * Time.deltaTime;}}

        if(PlayerSpeed >= Yellow && PlayerSpeed < Grellow)//aka they're in the yellow.
        {CurrentColour = "YELLOW"; ColouredBackground.color = cYellow;}

        if(PlayerSpeed >= Grellow && PlayerSpeed < Green)//aka they're in the grellow.
        {DistanceFromEnemy += 0.20f * Time.deltaTime; CurrentColour = "GRELLOW"; ColouredBackground.color = cGrellow;}
        if(PlayerSpeed >= Green)//aka they're in the green.
        {DistanceFromEnemy += 0.25f * Time.deltaTime; CurrentColour = "ORANGE"; ColouredBackground.color = cGreen;}
    }

    

        SharkDistanceUI.value = DistanceFromEnemy;
        if(DistanceFromEnemy < 3 || Chased){Exposure = Mathf.Lerp(Exposure, 0.25f, 3 * Time.deltaTime); Pinch = true; Blood.SetActive(true);}
        else{Exposure = Mathf.Lerp(Exposure, 1.37f, 3 * Time.deltaTime); Pinch = false; Blood.SetActive(false);}
        RenderSettings.skybox.SetFloat("_Exposure", Exposure);

        if(Pinch)
        {
            //Blood.GetComponent<Image>().Colour = 
        }

    }

    public void Chase()
    {
        DistanceFromEnemy = 1f;
        Player.SendMessage("BackFacing3D");
        Chased = true;
        SharkManager.SendMessage("beginchase");

        //This bit of the script takes every object tagged with SpeedChanger and then deletes them from the scene.
        GameObject[] speedupdownitems = GameObject.FindGameObjectsWithTag("SpeedChanger");
        foreach (GameObject item in speedupdownitems) {Destroy(item);}

        
    }


    public void SurvivedTheChase()
    {
        DistanceFromEnemy = 5;
        Player.SendMessage("FrontFacing3D");
        Chased = false;
        //SharkManager.SendMessage("endchase");
        
        TunnelManager.GetComponent<TunnelManager>().SetSpeedToYellow(Yellow);
    }


    
    public void Lv1()
    {
        Orange = 15;
        Yellow = 20;
        Grellow = 28;
        Green = 38;
    }
    public void Lv2()
    {
        Orange = 18;
        Yellow = 26;
        Grellow = 34;
        Green = 42;
    }
}
