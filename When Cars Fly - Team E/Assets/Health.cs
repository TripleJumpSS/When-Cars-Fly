using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float HP;
    public float iframes;
    public Slider HealthBar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(iframes > 0){iframes -= 1 * Time.deltaTime;}
        else if(iframes < 0){iframes = 0;}
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("BreakableHazard") && iframes == 0)
        {
            HP -= 2;
            HealthBar.value = HP;
            iframes = 1f;
        }
    }
}
