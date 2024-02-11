using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour, IInteractable
{

    private Dialogue_Manager manager;




    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<Dialogue_Manager>();
    }
    public void Interact()
    {
        AudioManager.Instance.PlayOneShot(FmodEvents.Instance.objectPickup, this.transform.position);
        gameObject.name = "Essence";
        Inventory.Instance.AddObjects(this.gameObject);
        manager.ShowThought("14");
        gameObject.SetActive(false);
        
    }

}
