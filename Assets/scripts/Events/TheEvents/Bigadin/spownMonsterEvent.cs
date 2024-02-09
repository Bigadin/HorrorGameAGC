using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spownMonsterEvent : GameEvent
{
    [SerializeField] Animator[] meubleAnimator;
    [SerializeField] GameObject Monster;
    public override void ConcreteEvent()
    {
        base.ConcreteEvent();
        spownMonster();

    }
    void spownMonster()
    {
        foreach (var anim in meubleAnimator)
        {
            anim.Play("MonsterEvent");
        }
        //play sound
        Monster.SetActive(true);

    }

}
