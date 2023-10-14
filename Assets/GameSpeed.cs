using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public GameObject PauseScreen;
    void Start()
    {
        PauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {Time.timeScale = 0f; PauseScreen.SetActive(true);}

    public void UnPause()
    {Time.timeScale = 1f; PauseScreen.SetActive(false);}
}
