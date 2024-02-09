using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicEvent : GameEvent
{

    [SerializeField]
    private Transform musicTrans;

    public override void ConcreteEvent()
    {
        base.ConcreteEvent();
        AudioManager.Instance.InitializeSound(FmodEvents.Instance.instruMusic, musicTrans, 1f,40f); ;

    }
}
