using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenEvent : GameEvent
{
    [SerializeField] eventObject[] eventObjects;
    public override void ConcreteEvent()
    {
        base.ConcreteEvent();
        GetComponent<Collider>().enabled = true;


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            kitchenEventTrigger();

        }
    }
    void kitchenEventTrigger()
    {
        foreach (var eventObject in eventObjects)
        {
            eventObject.evObjects.SetActive(true);
           
            //sound
            
        }
        StartCoroutine(eventDestroy());
    }
    IEnumerator eventDestroy()
    {
        yield return new WaitForSeconds(1f);
        foreach (var eventObject in eventObjects)
        {
            eventObject.evObjects.SetActive(false);
            

        }
        //play sound
        GetComponent<Collider>().enabled = false;

    }

}
[System.Serializable]
public class eventObject
{
    public string name;
    public GameObject evObjects;
}
