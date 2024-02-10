using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : Door
{
    
    [SerializeField] GameObject lights;
    private int count = 0;
    public  bool bathEvent;
    private EventInstance musicDramaEventInstance;
    private PLAYBACK_STATE musicDramaPlaybackState;
    private bool musicDramaPlaying = false;


    public override void Interact()
    {
        base.Interact();
        if(bathEvent)
        {
            lights.SetActive(true);
            StartCoroutine(desableLight());
            GetComponent<Door>().openDoor();
            LightBatterieManager.instance.offLight();
            bathEvent = false;
            musicDramaEventInstance = AudioManager.Instance.CreateInstance(FmodEvents.Instance.musicDrama);
            musicDramaPlaying=true; 
            AudioManager.Instance.PlayOneShot(FmodEvents.Instance.thunderShot, this.transform.position);
            musicDramaEventInstance.start();
            GetComponent<DoorTrigger>().enabled = false;
            

        }
        count++;
    }



IEnumerator desableLight()
{
    yield return new WaitForSeconds(3.2f);
    lights.SetActive(false);
        LightBatterieManager.instance.onLight();
}

public void StopMusicDrama()
    {
        if (musicDramaEventInstance.isValid())
        {
            musicDramaEventInstance.stop(STOP_MODE.IMMEDIATE);
            
        }
    }
}
