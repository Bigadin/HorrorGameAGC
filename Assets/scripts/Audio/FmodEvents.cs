using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FmodEvents : MonoBehaviour
{
    public static FmodEvents Instance { get; private set; }

    [field: SerializeField]
    public EventReference rain { get; private set; }
    [field: SerializeField]
    public EventReference footstepsWalkGrass { get; private set; }
    [field: SerializeField]
    public EventReference footstepsRunGrass { get; private set; }
    [field: SerializeField]
    public EventReference music { get; private set; }
    [field: SerializeField]
    public EventReference flashlight { get; private set; }
    [field: SerializeField]
    public EventReference carEngine { get; private set; }
    [field: SerializeField]
    public EventReference doorOpenClose { get; private set; }
    [field: SerializeField]
    public EventReference lightSwitch { get; private set; }
    [field: SerializeField]
    public EventReference lockedDoor { get; private set; }
    [field: SerializeField]
    public EventReference unlockDoor { get; private set; }
    [field: SerializeField]
    public EventReference keySound { get; private set; }
    [field: SerializeField]
    public EventReference papperPickup { get; private set; }
    [field: SerializeField]
    public EventReference objectPickup { get; private set; }
    [field: SerializeField]
    public EventReference houseMusicR { get; private set; }
    [field: SerializeField]
    public EventReference houseAmbiance { get; private set; }
    [field: SerializeField]
    public EventReference monsterWalk { get; private set; }
    [field: SerializeField]
    public EventReference monsterGrowl { get; private set; }
    [field: SerializeField]
    public EventReference chairMove { get; private set; }
    [field: SerializeField]
    public EventReference musicDrama { get; private set; }
    [field: SerializeField]
    public EventReference closingDoor { get; private set; }


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one instance of the FmodEvents");
        }
        Instance = this;
    }
}
