using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventChair : GameEvent
{
    [SerializeField]
    private Transform chairPosition;

    [SerializeField] Animator chairEventAnim;

    private EventInstance musicDramaEventInstance;
    private PLAYBACK_STATE musicDramaPlaybackState;
    private bool musicDramaPlaying=false;

    override public void ConcreteEvent()
    {
        
        chairEventAnim.Play("ChairEvent");

        AudioManager.Instance.PlayOneShot(FmodEvents.Instance.chairMove, chairPosition.position);

        // Play the music drama event and get its instance
        AudioManager.Instance.StopMusic();
        musicDramaEventInstance = AudioManager.Instance.CreateInstance(FmodEvents.Instance.musicDrama);
        musicDramaEventInstance.start();
        musicDramaPlaying = false;
    }


    void Update()
    {

        if (musicDramaEventInstance.isValid() && !musicDramaPlaying)
        {

            musicDramaEventInstance.getPlaybackState(out musicDramaPlaybackState);

            if (musicDramaPlaybackState == PLAYBACK_STATE.STOPPED)
            {
                musicDramaPlaying = true;
                Debug.Log("musicDrama event has finished playing");
                AudioManager.Instance.RelaunchMusic(musicDramaPlaying);
                
            }
        }
    }

    
}
