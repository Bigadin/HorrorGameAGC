using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        AudioManager.Instance.PlayOneShot(FmodEvents.Instance.objectPickup, this.transform.position);
        Inventory.Instance.AddObjects(this.gameObject);
    }

}
