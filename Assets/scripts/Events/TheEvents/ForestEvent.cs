using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestEvent : GameEvent
{
    override 
    public void ConcreteEvent()
    {
        base.ConcreteEvent();
        Debug.Log("I am in the forest let's goooo");
    }
}
