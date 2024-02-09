using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeEvent : GameEvent
{
    [SerializeField] Animator knifeAnimator;
    public override void ConcreteEvent()
    {
        base.ConcreteEvent();
        knifeAnimator.Play("knifeEvent");
        //sound
    }

}
