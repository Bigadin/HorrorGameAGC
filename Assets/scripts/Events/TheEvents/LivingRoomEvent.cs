using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomEvent : GameEvent
{
    [SerializeField]
    private Light tvLight;
    [SerializeField]
    private Transform tvPosition;

    public override void ConcreteEvent()
    {
        
        AudioManager.Instance.InitializeSound(FmodEvents.Instance.tvSound, tvPosition,1f,40f);
        tvLight.intensity = 100f;

    }
}
