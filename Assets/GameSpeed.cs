using System;
using System.Collections;
using System.Collections.Generic;
using FMOD;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSpeed : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject GameOverScreen;
    public GameObject SoundManager;
    public TMP_Text Points; public TMP_Text DistanceUIText; 
    void Start()
    {
        PauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {Time.timeScale = 0f; PauseScreen.SetActive(true); SoundManager.SendMessage("MuteAllButDrums");}

    public void UnPause()
    {Time.timeScale = 1f; PauseScreen.SetActive(false); SoundManager.SendMessage("Standard");}
    public void GameOver()
    {Time.timeScale = 0f; GameOverScreen.SetActive(true); Points.text = DistanceUIText.text;}
    public void Retry()
    {
        {Time.timeScale = 1f; SceneManager.LoadScene("Tunnel Scene");}
    }
}
