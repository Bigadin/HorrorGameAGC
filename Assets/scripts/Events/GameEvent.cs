using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameEvent : MonoBehaviour, ILaunchEvent
{
    [SerializeField]
    private int order=0;
    [SerializeField]
    private int launchOrder = 0;
    
    public void LaunchEvent()
    {
        if (order == launchOrder)
        {
            Debug.Log("Start Event");
            ConcreteEvent();
            UpdateOrder();
            EventManager.instance.RemoveEvent(this);
        }
       
        
    }
    private void Update()
    {
        Debug.Log("I am working");
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
        Debug.Log("Concrete");
    }
}
