using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundMeuble : MonoBehaviour, IInteractable
{

    private Dialogue_Manager dialogue_manager;

    private void Awake()
    {
        dialogue_manager= GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<Dialogue_Manager>();
    }
    public void PlayStart()
    {
        AudioManager.Instance.InitializeSound(FmodEvents.Instance.startSpawn, this.transform, 1f, 70f);
    }
    public void PlayEnd()
    {
        AudioManager.Instance.InitializeSound(FmodEvents.Instance.finishSpawn, this.transform, 1f, 70f);
    }

    public void Interact()
    {
        dialogue_manager.ShowThought("5");
    }
}
