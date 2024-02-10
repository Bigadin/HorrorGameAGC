using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour, IInteractable
{

    [SerializeField]
    private GameEvent musicEvent;
    [SerializeField]
    private Light tvLight;
    private Dialogue_Manager dialogue_manager;
    private void Awake()
    {
        dialogue_manager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<Dialogue_Manager>();
    }
    public void Interact()
    {
        AudioManager.Instance.StopSound();
        musicEvent.LaunchEvent();
        tvLight.intensity = 0f;
        this.enabled = false;
        dialogue_manager.ShowThought("6");
    }
}
