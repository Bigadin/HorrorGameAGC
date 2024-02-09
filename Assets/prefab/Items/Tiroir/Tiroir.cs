using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiroir : MonoBehaviour, IInteractable
{
    bool isOpen = false;
    public void Interact()
    {
        OpenDrawer();
    }
    void OpenDrawer()
    {

        Animator an = GetComponent<Animator>();
        if (!isOpen)
        {
            an.Play("openDr");
            isOpen = true;
        }
        else
        {
            an.Play("closeDr");
            isOpen = false;
        }
    }
}
