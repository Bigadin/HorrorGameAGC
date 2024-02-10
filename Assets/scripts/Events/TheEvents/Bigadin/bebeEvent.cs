using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bebeEvent : GameEvent
{

    [SerializeField] public Door roomDoor;
    [SerializeField]  NoteTrigger note;
    [SerializeField] public Animator[] LightAnim;

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
        note.gameObject.SetActive(true);
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
                
                isEventStart=false;
            }

        }
    }
    public IEnumerator WaitbeforeEnd()
    {
        yield return new WaitForSeconds(10);
        roomDoor.setdoorStat(Door.DoorState.Unlocked);
        LightAnim[0].enabled = false;
        LightAnim[1].enabled = false;
    }
}
