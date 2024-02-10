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
        if(this.name == "note001")
        {
            noteEvent.GetComponent<Collider>().enabled = true;
        }
        else if(this.name == "note002")
        {
            noteEvent.GetComponent<spownMonsterEvent>().spownMonster();
            noteEvent.LaunchEvent();

        }
        else if(this.name == "bebe event note")
        {
            noteEvent.LaunchEvent();
        }

        Destroy(this.gameObject);
    }


}
