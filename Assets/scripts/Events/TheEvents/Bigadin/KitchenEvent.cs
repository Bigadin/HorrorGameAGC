using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class KitchenEvent : GameEvent
{
    [SerializeField] eventObject[] eventObjects;
    [SerializeField]
    private Transform thunderPlace;
    private PLAYBACK_STATE musicDramaPlaybackState;
    private bool musicDramaPlaying = false;
    [SerializeField]
    private Transform knightPosition;
    [SerializeField]
    private Transform newKnightPosition;
    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void ConcreteEvent()
    {

            GetComponent<Collider>().enabled = true;
            
            AudioManager.Instance.StopMusic();
           
            SetDramaMusicInstance(AudioManager.Instance.CreateInstance(FmodEvents.Instance.dramaSpeed2));
            musicDramaEventInstance.start();
            musicDramaPlaying = true;
            AudioManager.Instance.PlayOneShot(FmodEvents.Instance.thunderShot, thunderPlace.position);
            foreach (var eventObject in eventObjects)
            {
                eventObject.evObjects.SetActive(true);
            }
            LightBatterieManager.instance.offLight();
            knightPosition.position = newKnightPosition.position;
            knightPosition.eulerAngles= newKnightPosition.eulerAngles;
            player.GetComponent<ControlPlayer>().canMove = false;
            StartCoroutine(eventDestroy());
        

    }
    private void OnTriggerStay(Collider other)
    {
       
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
        player.GetComponent<ControlPlayer>().canMove = true;

        LightBatterieManager.instance.onLight();

    }

}
[System.Serializable]
public class eventObject
{
    public string name;
    public GameObject evObjects;
}
