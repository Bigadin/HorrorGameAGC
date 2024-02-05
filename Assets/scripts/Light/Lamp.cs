using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField]
    private Light flashlight;
    private bool state=false;
    private float curentIntenisty;
    private void Awake()
    {
        
    }
    private void Start()
    {
        state = false;
        curentIntenisty = flashlight.intensity;
    }

    private void Update()
    {
        TurnOn_OFF();
    }

    private void TurnOn_OFF()
    {
        if(state && Input.GetKeyDown(KeyCode.F))
        {
            state= false;
            flashlight.intensity = 0;
            AudioManager.Instance.PlayOneShot(FmodEvents.Instance.flashlight,this.transform.position);
        }
        else if(!state && Input.GetKeyDown(KeyCode.F))
        {
            state= true;
            flashlight.intensity = curentIntenisty;
            AudioManager.Instance.PlayOneShot(FmodEvents.Instance.flashlight, this.transform.position);

        }
    }
}
