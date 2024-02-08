using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterieCharger : MonoBehaviour, IInteractable
{
    [SerializeField] Transform battrieIndicator;
    float timer = 5f;
    bool HasCharger = false;

    private void Start()
    {        
        battrieIndicator.gameObject.SetActive(true); 
        
    }
    private void Update()
    {
        if (HasCharger)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                battrieIndicator.gameObject.SetActive(true);
                HasCharger = false;
                timer = 5f;
            }
        }
    }

    public void Interact()
    {
        if (!HasCharger)
        {
            LightBatterieManager.instance.addBattery();
            HasCharger = true;
            battrieIndicator.gameObject.SetActive(false);
        }


    }

}
