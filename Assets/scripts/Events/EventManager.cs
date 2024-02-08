using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ILaunchEvent
{
    void LaunchEvent();
}

public class EventManager : MonoBehaviour
{
    [SerializeField]
    private List<GameEvent> events;
    public static EventManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {

            Debug.Log("There is more than one event Manager");
        }
        instance = this;    
    }

    public void AddEvent(GameEvent eventObject)
    {
        events.Add(eventObject);  
    }
    public void RemoveEvent(GameEvent eventObject) {
        events.Remove(eventObject);
        foreach(GameEvent gameEvent in events)
        {
            gameEvent.UpdateOrder();
        }
    }

    public List<GameEvent> GetEvents()
    {

        return events;
    }
}
