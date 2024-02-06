using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        AudioManager.Instance.PlayOneShot(FmodEvents.Instance.keySound,this.transform.position);
        Inventory.Instance.AddObjects(this.gameObject);
        Destroy(this.gameObject);
    }
}
