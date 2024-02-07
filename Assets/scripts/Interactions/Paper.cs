using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject paper;

    private ControlPlayer player;

    private void Awake()
    {
        player =GameObject.FindGameObjectWithTag("Player").GetComponent<ControlPlayer>();
    }
    public void Interact()
    {
        AudioManager.Instance.PlayOneShot(FmodEvents.Instance.papperPickup,this.transform.position);
        paper.SetActive(true);
        player.enabled = false;

    }
}
