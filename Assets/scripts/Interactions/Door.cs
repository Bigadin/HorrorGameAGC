using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IInteractable
{

    private Animator animator;
    private bool isOpen= false;
    [SerializeField]
    private string keyOpener;

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
    public virtual void Interact()
    {

        if (state == DoorState.Locked)
        {

            foreach (GameObject item in Inventory.Instance.GetGameObjects()) {
                if (item.gameObject.name == keyOpener) // hna zid el id t3 key
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
        AudioManager.Instance.PlayOneShot(FmodEvents.Instance.doorOpenClose, this.transform.position);
    }
    public void playCloseSound()
    {
        AudioManager.Instance.PlayOneShot(FmodEvents.Instance.closingDoor,this.transform.position);
    }
    public DoorState getdoorStat()// hadi monster ysha9ha
    {
        return state;
    }
    public void setdoorStat(DoorState st)// hadi monster ysha9ha
    {
        state = st;
    }
    public void Setbool(bool boola)
    {
        this.isOpen= boola;
    }
    public bool getBool()
    {
        return this.isOpen;
    }
    public string GetKeyOpener()
    {
        return keyOpener;
    }
    public void SetKeyOpener(string keyOpener)
    {
        this.keyOpener = keyOpener;
    }
    public DoorState GetState()
    {
        return state;
    }
    public void SetState(DoorState st)
    {
        this.state = st;
    }

    public void PlayEventSound()
    {
        AudioManager.Instance.InitializeSound(FmodEvents.Instance.slamDoor, gameObject.transform, 1f, 40f);
    }
}
