using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IInteractable
{

    private Animator animator;
    private bool isOpen= false;

    public enum DoorState {
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
                if (item.gameObject.name == "Key") // hna zid el id t3 key
                {
                    state=DoorState.Unlocked;
                    AudioManager.Instance?.PlayOneShot(FmodEvents.Instance.unlockDoor,this.transform.position);
                    break;
                }
            
            }
            if(state == DoorState.Locked) {
                isOpen = false;
                AudioManager.Instance?.PlayOneShot(FmodEvents.Instance.lockedDoor, this.transform.position);
            }
            
        }

        if (!isOpen && state == DoorState.Unlocked)
        {
            openDoor();
        }else if(isOpen && state == DoorState.Unlocked)
        {
            CloseDoor();
        }
        
    }
    public void openDoor()
    {
        isOpen = true;


        animator.SetTrigger("Open");
        AudioManager.Instance?.PlayOneShot(FmodEvents.Instance.doorOpenClose, this.transform.position);
    }
    public void CloseDoor()
    {
        isOpen = false;


        animator.SetTrigger("Close");
        AudioManager.Instance?.PlayOneShot(FmodEvents.Instance.doorOpenClose, this.transform.position);
    }
    public void playerOpenSound()// hadi dertha le animation event sema dir sound hna
    {

    }
    public void playCloseSound()
    {

    }
    public DoorState getdoorStat()// hadi monster ysha9ha
    {
        return state;
    }
}
