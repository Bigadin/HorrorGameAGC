using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spownMonsterEvent : GameEvent
{
    [SerializeField] Animator[] meubleAnimator;
    [SerializeField] GameObject Monster;
   
    public void spownMonster()
    {
        print("MOOOOOOOOOOOONSTRE");
        Monster.SetActive(true);
        foreach (var anim in meubleAnimator)
        {
            anim.Play("MonsterEvent");
        }
       

    }

}
