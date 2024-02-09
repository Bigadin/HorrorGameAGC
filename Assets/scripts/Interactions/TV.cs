using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour, IInteractable
{

    [SerializeField]
    private GameEvent musicEvent;
    [SerializeField]
    private Light tvLight;
    public void Interact()
    {
        AudioManager.Instance.StopSound();
        musicEvent.LaunchEvent();
        tvLight.intensity = 0f;
        this.enabled = false;
    }
}
