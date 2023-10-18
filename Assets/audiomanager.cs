using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using Unity.VisualScripting;

public class audiomanager : MonoBehaviour
{
    //[SerializeField] private EventReference musicplay;
    public static audiomanager instance { get; private set; }
    private static FMOD.Studio.EventInstance Music;
    public StudioEventEmitter studioEventEmitter;


    
    // Start is called before the first frame update
    void Awake()
    {
        FMODUnity.RuntimeManager.CreateInstance("event:/Underwater Music");

        if(instance != null)
        {
            Debug.LogError("Oops, there's more than one audiomanager. How did THAT get there?!");
        }
        instance = this;
    }


    public void MuteAllButDrums()
    {

        //studioEventEmitter.EventInstance.setParameterByName("HDrumsVolume", 0f);
        //studioEventEmitter.EventInstance.setParameterByName("SDrumsVolume", 0f);
        studioEventEmitter.EventInstance.setParameterByName("BBaseVolume", 0f);
        studioEventEmitter.EventInstance.setParameterByName("HMambaVolume", 0f);
        studioEventEmitter.EventInstance.setParameterByName("HStringsVolume", 0f);
        studioEventEmitter.EventInstance.setParameterByName("HXylophoneVolume", 0f);
        studioEventEmitter.EventInstance.setParameterByName("SPianoVolume", 0f);
        studioEventEmitter.EventInstance.setParameterByName("HStringsVolume", 0f);

    }

    public void Standard()
    {

        studioEventEmitter.EventInstance.setParameterByName("HDrumsVolume", 1f);
        studioEventEmitter.EventInstance.setParameterByName("SDrumsVolume", 1f);
        studioEventEmitter.EventInstance.setParameterByName("BBaseVolume", 1f);
        studioEventEmitter.EventInstance.setParameterByName("HMambaVolume", 1f);
        studioEventEmitter.EventInstance.setParameterByName("HStringsVolume", 1f);
        studioEventEmitter.EventInstance.setParameterByName("HXylophoneVolume", 1f);
        studioEventEmitter.EventInstance.setParameterByName("SPianoVolume", 1f);
        studioEventEmitter.EventInstance.setParameterByName("HStringsVolume", 1f);

    }

}
