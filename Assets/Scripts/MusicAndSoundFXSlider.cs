using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicAndSoundFXSlider : MonoBehaviour
{

public AudioMixer MusicMixer;

public void SetMusic(float soundLevel)
{
if(soundLevel > 0)
{MusicMixer.SetFloat ("MusicMixVol", soundLevel);}
else
{MusicMixer.SetFloat ("MusicMixVol", soundLevel * 2);}
}



}
