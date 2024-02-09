using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bebeEvent : GameEvent
{

    [SerializeField] Door roomDoor;
    [SerializeField] Animator[] LightAnim;

    bool isEventStart = false;
    public override void ConcreteEvent()
    {
        base.ConcreteEvent();
        if (!isEventStart)
        {
            StartCoroutine(WaitbeforeStart());
        }

    }
    IEnumerator WaitbeforeStart()
    {
        
        yield return new WaitForSeconds(10);
        isEventStart = true;
        // babe sound
        
        foreach (Animator anim in LightAnim)
        {
            anim.Play("DoorEvent");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (isEventStart)
            {
                roomDoor.CloseDoor();
                roomDoor.setdoorStat(Door.DoorState.Locked);
                StartCoroutine(WaitbeforeEnd());
                isEventStart=false;
            }

        }
    }
    IEnumerator WaitbeforeEnd()
    {
        yield return new WaitForSeconds(10);
        roomDoor.setdoorStat(Door.DoorState.Unlocked);
        LightAnim[0].enabled = false;
        LightAnim[1].enabled = false;
    }
}
