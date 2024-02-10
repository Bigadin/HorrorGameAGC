using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeEvent : GameEvent
{
    [SerializeField] Animator knifeAnimator;
    [SerializeField]
    private DoorTrigger door;
    public override void ConcreteEvent()
    {
        door.StopMusicDrama();
        knifeAnimator.Play("knifeEvent");
        //sound
    }

}
