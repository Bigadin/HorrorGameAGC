using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spownMonsterEvent : GameEvent
{
    [SerializeField] Animator[] meubleAnimator;
    [SerializeField] GameObject Monster;
    [SerializeField]
    private GameObject thoughtActivate;
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
        Monster.SetActive(true);
        thoughtActivate.SetActive(true);

    }

}
