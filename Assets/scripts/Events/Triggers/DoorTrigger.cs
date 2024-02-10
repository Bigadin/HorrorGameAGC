using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : Door
{
    [SerializeField]
    private List<Light> knightEyes;

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
            foreach (Light light in knightEyes)
            {
                light.intensity = 50f;
            }
            backgroundThunder.intensity = 1000f;
            musicDramaEventInstance = AudioManager.Instance.CreateInstance(FmodEvents.Instance.musicDrama);
            musicDramaPlaying=true; 
            AudioManager.Instance.PlayOneShot(FmodEvents.Instance.thunderShot, this.transform.position);
            musicDramaEventInstance.start();
            StartCoroutine(coolDownEnd());
        }
        count++;
    }


    private IEnumerator coolDownEnd()
    {
        yield return new WaitForSeconds(3f);
        foreach(Light light in knightEyes)
        {
            light.intensity = 0f;
            backgroundThunder.intensity = 0f;
        }

    }
    public void StopMusicDrama()
    {
        if (musicDramaEventInstance.isValid())
        {
            musicDramaEventInstance.stop(STOP_MODE.IMMEDIATE);
            
        }
    }
}
