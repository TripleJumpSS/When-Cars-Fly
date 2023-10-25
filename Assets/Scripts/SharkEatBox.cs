using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SharkEatBox : MonoBehaviour
{
    public GameObject GameManager; public GameObject Player;
    public bool MouthIsOpen;
    public bool InMahMouth;
    public bool Invincibility;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {InMahMouth = true;}
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {InMahMouth = false;}
    }
    void Update()
    {
        Invincibility = Player.GetComponent<MouseToMove>().iFrames;
        
        if(InMahMouth && MouthIsOpen && !Invincibility)
        {
            Player.SetActive(false);
            GameManager.GetComponent<GameManager>().GameOver();
        }
    }

    public void OpenYourMouth(){MouthIsOpen = true;}
    public void ShutYourMouth(){MouthIsOpen = false;}

}
