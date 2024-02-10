using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCheckpoint : MonoBehaviour
{
    [SerializeField] ControlPlayer cp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (cp != null)
            {
                cp.savePlayer();
            }
            gameObject.SetActive(false);
        }
    }
    
}
