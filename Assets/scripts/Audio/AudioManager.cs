using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private List<EventInstance> eventInstances;

    private EventInstance ambianceEventInstance;
    private EventInstance musicEventInstance;
    private EventInstance carEventInstance;

    private Scene scene;


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
        scene=SceneManager.GetActiveScene();
        Debug.Log(scene.buildIndex);
        if (scene.buildIndex == 1)
        {
            InitializeAmbiance(FmodEvents.Instance.rain);
            InitializeMusic(FmodEvents.Instance.music);

        }else if(scene.buildIndex == 2)
        {
            InitializeAmbiance(FmodEvents.Instance.houseAmbiance);
            InitializeMusic(FmodEvents.Instance.houseMusicR);
        }
        
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
        if(scene.buildIndex == 1)
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
        }else if(scene.buildIndex == 2)
        {
             ambianceEventInstance= CreateInstance(ambianceEventReference);
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
        
    }

    private void InitializeMusic(EventReference ambianceEventReference)
    {
        if(scene.buildIndex == 1)
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
        }else if( scene.buildIndex == 2)
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
        
    }

    public void InitializeCarHonking(EventReference carEventReference,Transform carPosition)
    {
        carEventInstance = CreateInstance(carEventReference);
        if (carEventInstance.isValid())
        {
            Debug.Log("Ambiance EventInstance created successfully");
            carEventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(carPosition, Vector3.zero));
            carEventInstance.start();
        }
        else
        {
            Debug.LogError("Failed to create Ambiance EventInstance");
        }
    }

    private void CleanUp()
    {
        foreach (var eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }

        // Clear the list after cleanup
        eventInstances.Clear();
    }


    private void OnDestroy()
    {
        CleanUp();
    }
    public void RelaunchMusic(bool hasFinished)
    {
        if(hasFinished)
        {
            InitializeMusic(FmodEvents.Instance.houseMusicR);
        }
    }

    public void StopMusic()
    {
        if ( musicEventInstance.isValid())
        {
            // Stop the music event instance
            musicEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            // Release the music event instance
            musicEventInstance.release();
        }
        else
        {
            Debug.LogWarning("Music event instance is not valid or null.");
        }
        
    }
}


