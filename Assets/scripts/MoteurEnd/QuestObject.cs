using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    [SerializeField] GameObject pickup_indicator;
    [SerializeField] Inventory playerInventory;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            pickup_indicator.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                pickup_indicator.SetActive(false);
                gameObject.SetActive(false);
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        pickup_indicator.SetActive(false);
    }

}
