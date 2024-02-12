using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class bebeEvent : GameEvent
{

    public Door roomDoor;
    public Door bibRoom;
    [SerializeField] NoteTrigger note;
    public Animator[] LightAnim;
    private Dialogue_Manager manager;
    [SerializeField]
    private GameObject monster;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<Dialogue_Manager>();

    }
    

    private bool isEventStart = false;
    public override void ConcreteEvent()
    {




    }
    public void StartEvent(float time)
    {
        StartCoroutine(WaitbeforeStart(time));
    }
    bool callOnce;
    IEnumerator WaitbeforeStart(float time)
    {
        
        yield return new WaitForSeconds(time);
        if(monster.GetComponent<MonsterAI>().deadPlayer == false)
        {
            AudioManager.Instance.InitializeSound(FmodEvents.Instance.babyCry, note.transform, 1f, 75f);
            manager.ShowThought("15");
            isEventStart = true;
            note.gameObject.SetActive(true);
            foreach (Animator anim in LightAnim)
            {
                anim.Play("DoorEvent");
            }
        }
        else
        {
            if (!callOnce)
            {
                StartCoroutine(WaitbeforeStart(4));
                callOnce = true;
            }
        }
       
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (isEventStart)
            {
                monster.SetActive(false);
                roomDoor.CloseDoor();
                roomDoor.setdoorStat(Door.DoorState.Locked);
                
                isEventStart=false;
            }

        }
    }
    public IEnumerator WaitbeforeEnd()
    {
      
        yield return new WaitForSeconds(5);
        AudioManager.Instance.StopSound();
        monster.SetActive(true);
        roomDoor.setdoorStat(Door.DoorState.Unlocked);
        bibRoom.setdoorStat(Door.DoorState.Unlocked);
        bibRoom.openDoor();
        LightAnim[0].enabled = false;
        LightAnim[1].enabled = false;
        AudioManager.Instance.RelaunchMusic();
        
    }
}
