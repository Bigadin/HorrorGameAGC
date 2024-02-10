using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;
    public float[] rotation;
    public List<GameObject> items;

    public List<GameEvent> events;
    public string scene;

    //Takes data from the player and stores them in the variables of this class
    public PlayerData(ControlPlayer player)
    {
        position = new float[3];
        rotation = new float[3];

        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        Vector3 eulerRotation = player.transform.rotation.eulerAngles;
        rotation[0] = eulerRotation.x;
        rotation[1] = eulerRotation.y;
        rotation[2] = eulerRotation.z;

        items = player.inventory.GetGameObjects();

        events = player.eventManager.GetEvents();

        scene = player.scene;
    }
}