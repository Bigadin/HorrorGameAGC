using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        AudioManager.Instance.PlayOneShot(FmodEvents.Instance.objectPickup, this.transform.position);
        gameObject.name = "Essence";
        Inventory.Instance.AddObjects(this.gameObject);

        gameObject.SetActive(false);
    }

}
