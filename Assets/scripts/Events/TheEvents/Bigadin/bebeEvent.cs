using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bebeEvent : GameEvent
{

     public Door roomDoor;
     public Door bibRoom;
    [SerializeField]  NoteTrigger note;
     public Animator[] LightAnim;

    private  bool isEventStart = false;
    public override void ConcreteEvent()
    {
        
       
       

    }
    public void StartEvent(float time)
    {
        StartCoroutine(WaitbeforeStart(time));
    }
    IEnumerator WaitbeforeStart(float time)
    {
        
        yield return new WaitForSeconds(time);
        isEventStart = true;
        AudioManager.Instance.InitializeSound(FmodEvents.Instance.babyCry, note.gameObject.transform, 1f, 70f);
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
      
        yield return new WaitForSeconds(5);
        
        roomDoor.setdoorStat(Door.DoorState.Unlocked);
        bibRoom.setdoorStat(Door.DoorState.Unlocked);
        bibRoom.openDoor();
        LightAnim[0].enabled = false;
        LightAnim[1].enabled = false;
        AudioManager.Instance.RelaunchMusic();
    }
}
