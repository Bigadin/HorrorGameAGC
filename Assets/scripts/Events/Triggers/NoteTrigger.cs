using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTrigger : Paper
{
    [SerializeField]
    private GameEvent noteEvent;

    public override void Interact()
    {
        base.Interact();
        noteEvent.LaunchEvent();
        //Invoke("executeLunchEvent",2);
        Destroy(this.gameObject);
    }
    void executeLunchEvent()
    {
        noteEvent.LaunchEvent();

    }

}
