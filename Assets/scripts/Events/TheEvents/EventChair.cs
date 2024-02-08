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
    override
    public void ConcreteEvent()
    {
      chairPosition.position = Vector3.Lerp(chairPosition.position, newPosition.position, speed * Time.deltaTime);
      AudioManager.Instance.PlayOneShot(FmodEvents.Instance.chairMove, chairPosition.position);
    }
}
