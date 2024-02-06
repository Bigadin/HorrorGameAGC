using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractable
{

    [SerializeField]
    private Light lamp;
    private bool on_off = false;
    [SerializeField]
    private float curentIntensity = 1500f;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        lamp.intensity = 0f;
    }
    public void Interact()
    {
        if (on_off)
        {
            on_off = false;
            AudioManager.Instance.PlayOneShot(FmodEvents.Instance.lightSwitch,this.transform.position);
            lamp.intensity = 0f;
            
        }
        else if (!on_off)
        {
            on_off = true;
            AudioManager.Instance.PlayOneShot(FmodEvents.Instance.lightSwitch, this.transform.position);
            lamp.intensity = curentIntensity;
            
        }

    }


}
