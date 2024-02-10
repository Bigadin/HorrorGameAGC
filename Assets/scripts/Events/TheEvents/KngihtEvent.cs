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
    private DoorTrigger doorScript;

    public override void ConcreteEvent()
    {
        AudioManager.Instance.StopMusic();
        doorScript.CloseDoor();
        doorScript.bathEvent = true;
        this.knightPosition.position = newKnightPosition.position;
        this.knightPosition.rotation = newKnightPosition.rotation;
        this.enabled = false;
        GetComponent<Collider>().enabled = false;
       
    }
 
}
