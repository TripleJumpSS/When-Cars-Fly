using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SharkEatBox : MonoBehaviour
{
    public GameObject GameManager;
    public bool MouthIsOpen;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && MouthIsOpen)
        {
            other.gameObject.SetActive(false);
            GameManager.GetComponent<GameManager>().GameOver();
        }
    }

    public void OpenYourMouth(){MouthIsOpen = true;}
    public void CloseYourMouth(){MouthIsOpen = false;}

}
