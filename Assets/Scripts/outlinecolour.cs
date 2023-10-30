using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outlinecolour : MonoBehaviour
{
    public bool Rainbows;
    public Color RainbowHue;
    public bool Seethrough;
    [SerializeField] float seconds;
    float timer = 0.0f;
    public bool yellowToGreen = true;
    public bool greenToRed = false;
    public bool redToBlue = false;
    public bool blueToYellow = false;

    void Start()
    {
        // Initialize color, set material color using HSVToRGB.
        RainbowHue = Color.HSVToRGB(.34f, .84f, .67f);
    }
        public void SeethroughDebris()
    {
        //GetComponent<Outline>().enabled = true;
        //Seethrough = true;
    }
    public void SeethroughOff()
    {
        GetComponent<Outline>().enabled = false;
        Seethrough = false;
    }

    public void RainbowOutline()
    {
        GetComponent<Outline>().enabled = true;
        Rainbows = true;
    }
    public void RainbowOff()
    {
        GetComponent<Outline>().enabled = false;
        Rainbows = false;
    }


    void Update()
    {
        if(Rainbows)
        {
            GetComponent<Outline>().OutlineColor = RainbowHue;
            GetComponent<Outline>().enabled = true;
        


       
        timer += Time.deltaTime/seconds;
 
        if (blueToYellow == true && greenToRed == false && redToBlue == false && yellowToGreen == false)
        {
            RainbowHue = Color.Lerp(Color.blue, Color.yellow, timer);
            if(timer >= 1.0f)
            {
                timer = 0.0f;
                blueToYellow = false;
                yellowToGreen = true;
            }
        }

        if (yellowToGreen == true && blueToYellow == false && redToBlue == false && greenToRed == false)
        {
            RainbowHue = Color.Lerp(Color.yellow, Color.red, timer);
            if (timer >= 1.0f)
            {
                timer = 0.0f;
                yellowToGreen = false;
                greenToRed = true;
            }
        }
 
        if (greenToRed == true && blueToYellow == false && redToBlue == false && yellowToGreen == false)
        {
            RainbowHue = Color.Lerp(Color.yellow, Color.red, timer);
            if (timer >= 1.0f)
            {
                timer = 0.0f;
                greenToRed = false;
                redToBlue = true;
            }
        }
 
        if (redToBlue == true && greenToRed == false && blueToYellow == false && yellowToGreen == false)
        {
            RainbowHue = Color.Lerp(Color.red, Color.blue, timer);
            if (timer >= 1.0f)
            {
                timer = 0.0f;
                redToBlue = false;
                blueToYellow = true;
            }
        }
        }
        else if(Seethrough)
        {
            GetComponent<Outline>().enabled = true;
            GetComponent<Outline>().OutlineColor = Color.white;
        }
    }
}
