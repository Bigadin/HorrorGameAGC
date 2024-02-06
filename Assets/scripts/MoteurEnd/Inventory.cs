using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Items;

    public static Inventory Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {

            Debug.Log("there is more than one inventory");
        }
        Instance = this;
    }

    public void AddObjects(GameObject gameObject)
    {

        Items.Add(gameObject);
    }

    public void RemoveObjects(GameObject gameGameObject)
    {
        Items.Remove(gameObject);
    }
    public List<GameObject> GetGameObjects()
    {

        return Items;
    }

}
