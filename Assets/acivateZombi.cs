using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acivateZombi : GameEvent
{
    // Start is called before the first frame update
    [SerializeField] GameObject zombi;
    [SerializeField] bebeEvent bebeEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            zombi.SetActive(true); // dir sound t3 zombi ki iteih ------> doint forget delay 9isma yelha9 lerd
            transform.parent.GetComponent<DoorEvent>().EndEvent();
            bebeEvent.StartEvent(60f);
            AudioManager.Instance.PlayOneShot(FmodEvents.Instance.dramaSpeed2, transform.position);
        }
    }
}
