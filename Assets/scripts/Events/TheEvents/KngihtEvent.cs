using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KngihtEvent : GameEvent
{
    [SerializeField]
    private Transform knightPosition;

    [SerializeField]
    private Transform newKnightPosition;
    [SerializeField]
    private Animator doorAnimator;
    [SerializeField]
    private Door doorScript;

    public override void ConcreteEvent()
    {
        base.ConcreteEvent();
        doorAnimator.SetTrigger("Close");
        doorScript.Setbool(false);
        this.knightPosition.position = newKnightPosition.position;
        this.knightPosition.rotation = newKnightPosition.rotation;
        AudioManager.Instance.StopMusic();
        EventManager.instance.StopEventMusic();
    }
}
