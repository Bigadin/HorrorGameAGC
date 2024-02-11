using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spownMonsterEvent : GameEvent
{
    [SerializeField] Animator[] meubleAnimator;
    [SerializeField] GameObject Monster;
    [SerializeField]
    private GameObject thoughtActivate;

    [SerializeField] DoorEvent DoorEvent;
    public void spownMonster()
    {
        StartDoorEvent();
        Monster.SetActive(true);
        foreach (var anim in meubleAnimator)
        {
            anim.Play("MonsterEvent");
        }
        Monster.SetActive(true);
        thoughtActivate.SetActive(true);

        SetDramaMusicInstance(AudioManager.Instance.CreateInstance(FmodEvents.Instance.musicDrama));
    }
    void StartDoorEvent()
    {
        DoorEvent.StartEvent(20f);
    }
}
