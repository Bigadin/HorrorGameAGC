using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moteur : MonoBehaviour
{
    [SerializeField] List<QuestObject> mustHave = new List<QuestObject>();
    [SerializeField] List<QuestObject> setupObjects = new List<QuestObject>();


    bool turnONengin;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Inventory inv = other.GetComponent<Inventory>();
                if (inv.checkListObject())
                {
                    foreach(QuestObject obj in inv.QuestObjects)
                    {
                        if(!setupObjects.Contains(obj))
                            setupObjects.Add(obj);
                    }
                }
                turnONengin = checkValidity();
            }
        }
    }
    private void Update()
    {
        if (turnONengin)
        {
            //event start engine and turn on the light
            print("THE ENGIN START");
        }
    }
    bool checkValidity()
    {
        foreach (var obj in mustHave)
        {
            if (!setupObjects.Contains(obj))
            {
                turnONengin = false;
                return false;
            }
        }
        return true;
    }
}
