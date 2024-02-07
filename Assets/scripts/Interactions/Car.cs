using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour, IInteractable
{
    private Dialogue_Manager dialogue_manager;
    private void Awake()
    {
        dialogue_manager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<Dialogue_Manager>();
    }

    private void Start()
    {
        AudioManager.Instance.InitializeCarHonking(FmodEvents.Instance.carEngine, this.transform);
    }
    public void Interact()
    {
        dialogue_manager.ShowThought("1");
    }
}
