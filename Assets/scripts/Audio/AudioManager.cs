using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditorInternal;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private List<EventInstance> eventInstances;

    private EventInstance ambianceEventInstance;
    private EventInstance musicEventInstance;
    private EventInstance carEventInstance;
    private EventInstance randomSoundInstance;
    private Scene scene;

    private RuntimeManager studioSystem;

    [Range(0f, 1f)]
    public float masteVolume = 1f;

    private Bus masterBus;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one instance of the AudioManger");
        }
        Instance = this;
        eventInstances = new List<EventInstance>();

        masterBus = RuntimeManager.GetBus("bus:/");
    }

    private void Update()
    {
        masterBus.setVolume(masteVolume);
    }

    private void Start()
    {
        scene = SceneManager.GetActiveScene();

        Debug.Log(scene.buildIndex);
        if (scene.buildIndex == 1)
        {
            InitializeAmbiance(FmodEvents.Instance.rain);
            InitializeMusic(FmodEvents.Instance.music);

        }
        else if (scene.buildIndex == 2)
        {
            InitializeAmbiance(FmodEvents.Instance.houseAmbiance);
            InitializeMusic(FmodEvents.Instance.houseMusicR);
        }
        InvokeRepeating(nameof(RelaunchMusic), 60f, 60f);

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
        if (scene.buildIndex == 1)
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
        else if (scene.buildIndex == 2)
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

    }

    private void InitializeMusic(EventReference ambianceEventReference)
    {
        if (scene.buildIndex == 1)
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
        else if (scene.buildIndex == 2)
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

    public void InitializeCarHonking(EventReference carEventReference, Transform carPosition)
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

    public void InitializeSound(EventReference eventReference, Transform soundPosition,float minDistance,float maxDistance)
    {
        randomSoundInstance = CreateInstance(eventReference);
        if (randomSoundInstance.isValid())
        {
            Debug.Log("Ambiance EventInstance created successfully");
            randomSoundInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(soundPosition, Vector3.zero));

            randomSoundInstance.setProperty(EVENT_PROPERTY.MINIMUM_DISTANCE, minDistance);
            randomSoundInstance.setProperty(EVENT_PROPERTY.MAXIMUM_DISTANCE, maxDistance);
            randomSoundInstance.start();
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
    public void RelaunchMusic()
    {
        if (musicEventInstance.isValid())
        {
            musicEventInstance.getPlaybackState(out PLAYBACK_STATE playbackState);
            if (playbackState == PLAYBACK_STATE.STOPPED)
            {
                InitializeMusic(FmodEvents.Instance.houseMusicR);
            }
        }
        else
        {
            InitializeMusic(FmodEvents.Instance.houseMusicR);
        }
    }


    public void StopMusic()
    {
        if (musicEventInstance.isValid())
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

    public void StopSound()
    {
        if(randomSoundInstance.isValid())
        {
            randomSoundInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            randomSoundInstance.release();
        }
        else
        {
            Debug.LogWarning("Music event instance is not valid or null.");
        }
    }
}


