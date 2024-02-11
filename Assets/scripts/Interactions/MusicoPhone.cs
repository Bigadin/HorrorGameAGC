using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicoPhone : MonoBehaviour, IInteractable
{
    private Transform player;

    [SerializeField]
    private GameObject note;

    [SerializeField]
    private GameObject key;

    private bool canActivate=false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    public void Interact()
    {
        if(canActivate) {
            AudioManager.Instance.StopSound();
            AudioManager.Instance.PlayOneShot(FmodEvents.Instance.babySound, player.position - Vector3.back * 2f);
            note.SetActive(true);
            key.SetActive(true);
            this.enabled = false;
        }
       
    }

    public void SetActivate(bool activater)
    {
        canActivate = activater;
    }

}
