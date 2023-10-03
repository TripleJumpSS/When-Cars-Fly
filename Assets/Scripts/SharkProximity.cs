using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SharkProximity : MonoBehaviour
{
    public float PlayerSpeed; public GameObject TunnelManager;
    public float DistanceFromEnemy;
    public Slider SharkDistanceUI;
    public float Orange; public float Yellow; public float Grellow; public float Green;
    public string CurrentColour; public Image ColouredBackground;
    public Color cRed; public Color cOrange; public Color cYellow; public Color cGrellow; public Color cGreen;

    void Start()
    {
        Lv1();
        DistanceFromEnemy = 5;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSpeed = TunnelManager.GetComponent<TunnelManager>()._speed;

        if(DistanceFromEnemy < 1){DistanceFromEnemy = 1;}
        if(DistanceFromEnemy > 10){DistanceFromEnemy = 10;}

        if(PlayerSpeed < Orange)//aka they're in the red.
        {DistanceFromEnemy -= 1 * Time.deltaTime; CurrentColour = "RED"; ColouredBackground.color = cRed;}
        if(PlayerSpeed > Orange && PlayerSpeed < Yellow)//aka they're in the orange.
        {DistanceFromEnemy -= 0.5f * Time.deltaTime; CurrentColour = "ORANGE"; ColouredBackground.color = cOrange;}

        if(PlayerSpeed > Yellow && PlayerSpeed < Grellow)//aka they're in the yellow.
        {CurrentColour = "YELLOW"; ColouredBackground.color = cYellow;}

        if(PlayerSpeed > Grellow && PlayerSpeed < Green)//aka they're in the grellow.
        {DistanceFromEnemy += 0.5f * Time.deltaTime; CurrentColour = "GRELLOW"; ColouredBackground.color = cGrellow;}
        if(PlayerSpeed > Green)//aka they're in the green.
        {DistanceFromEnemy += 1 * Time.deltaTime; CurrentColour = "ORANGE"; ColouredBackground.color = cGreen;}

        SharkDistanceUI.value = DistanceFromEnemy;

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
