using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventChair : GameEvent
{
    [SerializeField]
    private Transform chairPosition;
    [SerializeField]
    private Transform newPosition;
    [SerializeField]
    private float speed;

    [SerializeField] Animator chairEventAnim;
    override
    public void ConcreteEvent()
    {
        chairEventAnim.Play("ChairEvent");
      AudioManager.Instance.PlayOneShot(FmodEvents.Instance.chairMove, chairPosition.position);
    }
}
