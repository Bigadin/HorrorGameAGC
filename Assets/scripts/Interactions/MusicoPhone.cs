using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicoPhone : MonoBehaviour, IInteractable
{
    private Transform player;
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    public void Interact()
    {
        AudioManager.Instance.StopSound();
        AudioManager.Instance.PlayOneShot(FmodEvents.Instance.babySound, player.position - Vector3.back * 2f);
        this.enabled = false;
    }

}
