using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource CurrentTrack;
    //public AudioSource[] NotCurrent;
    public AudioSource PreviousTrack;
    public AudioSource MainTheme; public AudioSource Pinch; public AudioSource Chase;
    public AudioSource Invincibility; public bool Invincible;
    public bool GameClear;

    public GameObject GameManager;
    public GameObject Player;
    void Start()
    {
        MainTheme.volume = 1;
        Pinch.volume = 0;
        Chase.volume = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTrack.volume += 0.01f;
        PreviousTrack.volume -= 0.01f;

        if(Input.GetKeyDown(KeyCode.Z)){PlayMainTheme();}
        if(Input.GetKeyDown(KeyCode.X)){PlayPinch();}
        if(Input.GetKeyDown(KeyCode.C)){PlayChase();}
        if(Input.GetKeyDown(KeyCode.V)){Invincible =! Invincible;}

        if(Invincible){Invincibility.volume += 0.01f;}
        else{Invincibility.volume -= 0.01f;}



        if(!GameManager.GetComponent<SharkProximity>().Pinch && !GameManager.GetComponent<SharkProximity>().Chased 
        && CurrentTrack != MainTheme)
        {PlayMainTheme();}

        if(GameManager.GetComponent<SharkProximity>().Chased
        && CurrentTrack != Chase)
        {PlayChase();}

        if(GameManager.GetComponent<SharkProximity>().Pinch && !GameManager.GetComponent<SharkProximity>().Chased
        && CurrentTrack != Pinch)
        {PlayPinch();}

        if(Player.GetComponent<MouseToMove>().Invinciblestar)
        {InvincibilityDrumsOn();}
        else
        {InvincibilityDrumsOff();}

        if(Player.activeInHierarchy == false)
        {Silence();}

    }

    public void PlayMainTheme()
    {PreviousTrack = CurrentTrack; CurrentTrack = MainTheme;}
    public void PlayPinch()
    {PreviousTrack = MainTheme; CurrentTrack = Pinch;} 

    public void PlayChase()
    {PreviousTrack = CurrentTrack; CurrentTrack = Chase;} 

    public void Silence()
    {PreviousTrack = CurrentTrack; CurrentTrack = null;} 
    public void InvincibilityDrumsOn()
    {Invincible = true;}
    public void InvincibilityDrumsOff()
    {Invincible = false;}

}