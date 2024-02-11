using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvent : GameEvent
{
    [SerializeField] Animator[] AllAnim;
    
    [SerializeField] Door roomDoor;
    public float timeBeforeStart = 30f;// hada 9bl mayebda ki yedkhl fla chambre
    public float timestopingAnimation = 10f;

    bool IsEventStart = false; // hada li i9ol ida event bda
    public override void ConcreteEvent()
    {
        
        if(!IsEventStart)
        {
            StartCoroutine(DoorEventStart());
            
        }
    }
    IEnumerator DoorEventStart()
    {
        yield return new WaitForSeconds(timeBeforeStart); // ki yedkhel la chambre isena 3s besh ybda event
        IsEventStart = true;
        allTheEventTriggers();
    }
    void allTheEventTriggers() // hna li kayen g3 3fayess t3 sound
    {
       foreach(var anim in AllAnim)
        {
            anim.Play("DoorEvent");
        }
        // sound t3 khbit
    }

    private void OnTriggerStay(Collider other)// hna c'est pour check ida player raho wela
    {
        if (other.tag == "Player")
        {
            if (IsEventStart)
            {
                roomDoor.CloseDoor();
                roomDoor.setdoorStat(Door.DoorState.Locked);
                AllAnim[0].transform.GetComponent<Door>().setdoorStat(Door.DoorState.Unlocked);
                StartCoroutine(StopDoor());
                GetComponent<BoxCollider>().enabled = false;
            }
        }

    }
    IEnumerator StopDoor() // hnaya stop g3 sound
    {
        yield return new WaitForSeconds(timestopingAnimation);
        AllAnim[0].SetTrigger("StopDoorEvent");
        AllAnim[1].enabled = false;
        AllAnim[2].enabled = false;
    }

    public void EndEvent() // hadi ki yekhlass el event go check zombiSpown child t3 had el objet
    {
        roomDoor.setdoorStat(Door.DoorState.Unlocked);
        roomDoor.openDoor();
        
    }
}
