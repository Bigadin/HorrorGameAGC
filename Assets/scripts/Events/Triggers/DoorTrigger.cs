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
            backgroundThunder.intensity = 500f;
            musicDramaEventInstance = AudioManager.Instance.CreateInstance(FmodEvents.Instance.musicDrama);
            AudioManager.Instance.PlayOneShot(FmodEvents.Instance.thunderShot, this.transform.position);
            musicDramaEventInstance.start();
            StartCoroutine(coolDownEnd());
        }
        count++;
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

    private IEnumerator coolDownEnd()
    {
        yield return new WaitForSeconds(3f);
        foreach(Light light in knightEyes)
        {
            light.intensity = 0f;
            backgroundThunder.intensity = 0f;
        }

    }
}
