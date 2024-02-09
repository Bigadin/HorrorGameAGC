using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acivateZombi : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject zombi;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            zombi.SetActive(true); // dir sound t3 zombi ki iteih ------> doint forget delay 9isma yelha9 lerd
            transform.parent.GetComponent<DoorEvent>().EndEvent();
        }
    }
}
