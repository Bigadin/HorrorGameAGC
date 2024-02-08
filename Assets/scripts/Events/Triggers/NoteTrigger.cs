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
        Destroy(this.gameObject);
    }
}
