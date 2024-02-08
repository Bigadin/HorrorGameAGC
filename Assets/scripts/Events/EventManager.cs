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
    private List<ILaunchEvent> events;  

    public void AddEvent(ILaunchEvent eventObject)
    {
        events.Add(eventObject);  
    }
    public void RemoveEvent(ILaunchEvent eventObject) {
        events.Remove(eventObject);
    }

    public List<ILaunchEvent> GetEvents()
    {

        return events;
    }
}
