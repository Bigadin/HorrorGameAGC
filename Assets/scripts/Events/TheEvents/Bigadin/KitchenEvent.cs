using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KitchenEvent : GameEvent
{
    [SerializeField] eventObject[] eventObjects;
    [SerializeField]
    private Transform thunderPlace;
    private EventInstance musicDramaEventInstance;
    private PLAYBACK_STATE musicDramaPlaybackState;
    private bool musicDramaPlaying = false;
    public override void ConcreteEvent()
    {
            base.ConcreteEvent();
            GetComponent<Collider>().enabled = true;
           
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (var eventObject in eventObjects)
            {
                eventObject.evObjects.SetActive(true);

                AudioManager.Instance.PlayOneShot(FmodEvents.Instance.thunderShot, thunderPlace.position);
                AudioManager.Instance.StopMusic();
                musicDramaEventInstance = AudioManager.Instance.CreateInstance(FmodEvents.Instance.dramaSpeed2);
                musicDramaEventInstance.start();
                musicDramaPlaying = true;
            }
            StartCoroutine(eventDestroy());
        }
    }

    private void Update()
    {
        if (musicDramaEventInstance.isValid() && musicDramaPlaying)
        {

            musicDramaEventInstance.getPlaybackState(out musicDramaPlaybackState);

            if (musicDramaPlaybackState == PLAYBACK_STATE.STOPPED)
            {
                musicDramaPlaying = false;
                Debug.Log("musicDrama event has finished playing");
                AudioManager.Instance.RelaunchMusic();
                EventManager.instance.RemoveEvent(this);

            }
        }
    }

    IEnumerator eventDestroy()
    {
        yield return new WaitForSeconds(2f);
        foreach (var eventObject in eventObjects)
        {
            eventObject.evObjects.SetActive(false);
            

        }
        //play sound
        GetComponent<Collider>().enabled = false;

    }

}
[System.Serializable]
public class eventObject
{
    public string name;
    public GameObject evObjects;
}
