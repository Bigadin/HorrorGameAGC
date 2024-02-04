using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private List<EventInstance> eventInstances;

    private EventInstance ambianceEventInstance;
    private EventInstance musicEventInstance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one instance of the AudioManger");
        }
        Instance = this;
        eventInstances = new List<EventInstance>();
    }

    private void Start()
    {
        InitializeAmbiance(FmodEvents.Instance.rain);
        InitializeMusic(FmodEvents.Instance.music);
    }

    public void PlayOneShot(EventReference sound, Vector3 position)
    {
        RuntimeManager.PlayOneShot(sound, position);
    }

    public EventInstance CreateInstance(EventReference sound)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(sound);
        Debug.Log(sound.ToString());
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    private void InitializeAmbiance(EventReference ambianceEventReference)
    {
        ambianceEventInstance = CreateInstance(ambianceEventReference);
        if (ambianceEventInstance.isValid())
        {
            Debug.Log("Ambiance EventInstance created successfully");
            ambianceEventInstance.start();
        }
        else
        {
            Debug.LogError("Failed to create Ambiance EventInstance");
        }
    }

    private void InitializeMusic(EventReference ambianceEventReference)
    {
        musicEventInstance = CreateInstance(ambianceEventReference);
        if (musicEventInstance.isValid())
        {
            Debug.Log("Ambiance EventInstance created successfully");
            musicEventInstance.start();
        }
        else
        {
            Debug.LogError("Failed to create Ambiance EventInstance");
        }
    }

    private void CleanUp()
    {
        foreach (var eventInstance in eventInstances) {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        
        }

    }

    private void OnDestroy()
    {
        CleanUp();
    }

}


