using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour, ILaunchEvent
{

    
    public void LaunchEvent()
    {
        Debug.Log("Start Event");
        throw new System.NotImplementedException();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LaunchEvent();
        }
    }

    public void OnLaunchEvent()
    {


    }

}
