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
    public void RemoveEvent(GameEvent eventObject)
    {
        events.Remove(eventObject);
       
    }

    public List<GameEvent> GetEvents()
    {
        return events;
    }

    public void SetEvents(List<GameEvent> events)
    {
        this.events = events;
    }

    public void StopEventMusic()
    {
        foreach(GameEvent gameEvent in events)
        {
            gameEvent.StopEventMusic();
        }
    }
}
