using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource CurrentTrack;
    public AudioSource[] NotCurrent;
    public AudioSource PreviousTrack;
    public AudioSource MainTheme; public AudioSource Pinch; public AudioSource Chase;
    //public AudioSource ViCtory; public AudioSource DreamScape; public AudioSource DiaLogue;
    public bool GameClear;
    void Start()
    {
        //GameClear = false;
        MainTheme.volume = 1;
        Pinch.volume = 0;
        Chase.volume = 0;
        //ViCtory.enabled = false;
        //DreamScape.volume = 0;
        //DiaLogue.volume = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTrack.volume += 0.01f;
        PreviousTrack.volume -= 0.01f;
        
        //foreach (AudioSource notyou in NotCurrent){if(notyou.name != CurrentTrack.name){notyou.volume -= 0.01f;}} 

        if(Input.GetKeyDown(KeyCode.Z)){PlayMainTheme();}
        if(Input.GetKeyDown(KeyCode.X)){PlayPinch();}
        if(Input.GetKeyDown(KeyCode.C)){PlayChase();}
    }

    public void PlayMainTheme()
    {if(GameClear){return;} PreviousTrack = CurrentTrack; CurrentTrack = MainTheme; }
    public void PlayPinch()
    {if(GameClear){return;} PreviousTrack = CurrentTrack; CurrentTrack = Pinch;} 

    public void PlayChase()
    {if(GameClear){return;} PreviousTrack = CurrentTrack; CurrentTrack = Chase;} 

/*    public void Puzzle()
    {if(GameClear){return;} PreviousTrack = CurrentTrack; CurrentTrack = PuzZle;} 

    public void Discovered()
    {if(GameClear){return;} PreviousTrack = CurrentTrack; CurrentTrack = DisCovered;} 
    public IEnumerator Victory()
    {
        GameClear = true;
        UnDiscovered.volume = 0;
        DisCovered.volume = 0;
        PuzZle.volume = 0;
        DreamScape.volume = 0;
        DiaLogue.volume = 0;
        yield return new WaitForSeconds(0.5f);
        ViCtory.enabled = true;
        PreviousTrack = CurrentTrack; 
        UnDiscovered.volume = 0;
        DisCovered.volume = 0;
        PuzZle.volume = 0;
        DreamScape.volume = 0;
        DiaLogue.volume = 0;
        CurrentTrack = ViCtory;
    }*/
    public void Silence()
    {PreviousTrack = CurrentTrack; CurrentTrack = null;} 

}