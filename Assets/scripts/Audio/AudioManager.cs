using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private EventInstance ambianceEventInstance;
    private EventInstance rainEventInstance;  // Add this line

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one instance of the AudioManger");
        }
        Instance = this;
    }

    private void Start()
    {
        InitializeAmbiance(FmodEvents.Instance.rain);
        InitializeRain();  // Add this line
    }

    public void PlayOneShot(EventReference sound, Vector3 position)
    {
        RuntimeManager.PlayOneShot(sound, position);
    }

    public EventInstance CreateInstance(EventReference sound)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(sound);
        Debug.Log(sound.ToString());
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

    private void InitializeRain()
    {
        rainEventInstance = CreateInstance(FmodEvents.Instance.rain);  // Adjust the event reference
        if (rainEventInstance.isValid())
        {
            Debug.Log("Rain EventInstance created successfully");
            rainEventInstance.start();
        }
        else
        {
            Debug.LogError("Failed to create Rain EventInstance");
        }
    }
}


