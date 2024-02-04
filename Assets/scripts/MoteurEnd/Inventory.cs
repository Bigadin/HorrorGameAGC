using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<QuestObject> QuestObjects = new List<QuestObject>();

    public void addObject(QuestObject obj)
    {
        QuestObjects.Add(obj);
    }
    public bool checkListObject()
    {
        if (QuestObjects.Count > 0) return true;
        return false;
    }
}
