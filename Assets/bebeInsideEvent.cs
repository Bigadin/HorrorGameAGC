using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bebeInsideEvent : bebeEvent
{
    public override void ConcreteEvent()
    {
        foreach (var e in LightAnim) {
            e.Play("BebeEvent");
        }
        this.roomDoor = base.roomDoor;
        StartCoroutine(base.WaitbeforeEnd());
    }
    
    
}
