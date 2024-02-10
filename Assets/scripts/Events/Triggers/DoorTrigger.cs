using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : Door
{
    

    [SerializeField]
    private Light backgroundThunder;

    private int count = 0;

    private EventInstance musicDramaEventInstance;
    private PLAYBACK_STATE musicDramaPlaybackState;
    private bool musicDramaPlaying = false;


    public override void Interact()
    {
        base.Interact();
        if(count == 1)
        {
            LightBatterieManager.instance.offLight();
            musicDramaEventInstance = AudioManager.Instance.CreateInstance(FmodEvents.Instance.musicDrama);
            musicDramaPlaying=true; 
            AudioManager.Instance.PlayOneShot(FmodEvents.Instance.thunderShot, this.transform.position);
            musicDramaEventInstance.start();
        }
        count++;
    }


  
    public void StopMusicDrama()
    {
        if (musicDramaEventInstance.isValid())
        {
            musicDramaEventInstance.stop(STOP_MODE.IMMEDIATE);
            
        }
    }
}
