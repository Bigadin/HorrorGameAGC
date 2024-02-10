using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour, IInteractable
{
    private Dialogue_Manager manager;


   

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<Dialogue_Manager>();
    }
    public void Interact()
    {
        AudioManager.Instance.PlayOneShot(FmodEvents.Instance.keySound,this.transform.position);
        Inventory.Instance.AddObjects(this.gameObject);
        manager.ShowThought("13");
        gameObject.SetActive(false);
        
    }
}
