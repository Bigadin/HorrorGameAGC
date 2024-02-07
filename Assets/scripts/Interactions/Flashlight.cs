using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour,IInteractable
{
    [SerializeField]
    private GameObject flashlight;
    public void Interact()
    {
        flashlight.SetActive(true);
        AudioManager.Instance.PlayOneShot(FmodEvents.Instance.objectPickup, this.transform.position);
        this.gameObject.SetActive(false);
        
    }

    
}
