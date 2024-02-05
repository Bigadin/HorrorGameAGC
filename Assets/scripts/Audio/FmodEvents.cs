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
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one instance of the FmodEvents");
        }
        Instance = this;
    }
}
