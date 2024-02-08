using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Paper : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject paper;

    [SerializeField]
    private TextMeshProUGUI noteText;

    [SerializeField,TextArea(3, 10)]
    private string realText;

    private ControlPlayer player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlPlayer>();
    }

    public virtual void Interact()
    {

        AudioManager.Instance.PlayOneShot(FmodEvents.Instance.papperPickup,this.transform.position);
        paper.SetActive(true);
        noteText.text = realText;
        player.enabled = false;

    }
}
