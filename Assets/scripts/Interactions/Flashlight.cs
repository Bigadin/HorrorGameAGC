using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour,IInteractable
{
    [SerializeField]
    private GameObject flashlight;
    public void interact()
    {
        flashlight.SetActive(true);
        Debug.Log("sa marche");
        Destroy(this.gameObject);
        
    }

    
}
