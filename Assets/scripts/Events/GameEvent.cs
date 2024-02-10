using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameEvent : MonoBehaviour, ILaunchEvent
{
    [SerializeField]
    private static int order = 0;
    [SerializeField]
    private int launchOrder = 0;
    public EventInstance musicDramaEventInstance {  get; private set; }

    public void LaunchEvent()
    {
        if (order == launchOrder)
        {
            Debug.Log("Start Event");
            EventManager.instance.StopEventMusic();
            ConcreteEvent();
            UpdateOrder();
            Debug.Log(order);
        }
       
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            LaunchEvent();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LaunchEvent();
        }
    }
    public void UpdateOrder()
    {
        order++;
    }

    public virtual void ConcreteEvent()
    {
        EventManager.instance.StopEventMusic();
    }
    public virtual void StopEventMusic()
    {
        if (musicDramaEventInstance.isValid())
        {
            musicDramaEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        else
        {
            Debug.Log("There is problem");
        }
    }
    public void SetDramaMusicInstance(EventInstance instance)
    {
        musicDramaEventInstance = instance;
    }
    
    public int getOrder()
    {
        return order;
    }
    public int getLaunchOrder()
    {
        return launchOrder;
    }
    public void RelaunchMusic()
    {
        if(musicDramaEventInstance.isValid() ==false) {
            AudioManager.Instance.RelaunchMusic();
        
        }
    }
}
