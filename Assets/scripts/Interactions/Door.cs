using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IInteractable
{

    private Animator animator;
    private bool isOpen= false;

    private enum DoorState {
    Locked,
    Unlocked
    }

    [SerializeField]
    private DoorState state;    


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Interact()
    {

        if (state == DoorState.Locked)
        {

            foreach (GameObject item in Inventory.Instance.GetGameObjects()) {
                if (item.gameObject.name == "Key")
                {
                    state=DoorState.Unlocked;
                    AudioManager.Instance.PlayOneShot(FmodEvents.Instance.unlockDoor,this.transform.position);
                    break;
                }
            
            }
            if(state == DoorState.Locked) {
                isOpen = false;
                AudioManager.Instance.PlayOneShot(FmodEvents.Instance.lockedDoor, this.transform.position);
            }
            
        }

        if (!isOpen && state == DoorState.Unlocked)
        {
            isOpen = true;
            animator.SetBool("Open", true);
            animator.SetBool("Close", false);
            AudioManager.Instance.PlayOneShot(FmodEvents.Instance.doorOpenClose, this.transform.position);
        }else if(isOpen && state == DoorState.Unlocked)
        {
            isOpen=false;
            animator.SetBool("Close", true);
            animator.SetBool("Open", false);
            AudioManager.Instance.PlayOneShot(FmodEvents.Instance.doorOpenClose, this.transform.position);
        }
        
    }

    
}
