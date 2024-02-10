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
        
        StartCoroutine(base.WaitbeforeEnd());
    }
    
    
}
