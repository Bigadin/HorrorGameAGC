using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour,IInteractable
{
    [SerializeField]
    GameObject flashlight;

    [SerializeField] ControlPlayer cp;
    public void Interact()
    {
        flashlight.SetActive(true);
        cp.isFlashGrabbed = true;
        Debug.Log("sa marche");
        this.gameObject.SetActive(false);
    }
}
