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
    private PLAYBACK_STATE musicDramaPlaybackState;
    private bool musicDramaPlaying = false;
    public override void ConcreteEvent()
    {
            GetComponent<Collider>().enabled = true;
           
        
    }
    private void OnTriggerStay(Collider other)
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayOneShot(FmodEvents.Instance.thunderShot, thunderPlace.position);
            AudioManager.Instance.StopMusic();
            SetDramaMusicInstance(AudioManager.Instance.CreateInstance(FmodEvents.Instance.dramaSpeed2));
            musicDramaEventInstance.start();
            musicDramaPlaying = true;
            foreach (var eventObject in eventObjects)
            {
                eventObject.evObjects.SetActive(true);
            }
            StartCoroutine(eventDestroy());
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
