using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IInteractable
{

    private Animator animator;
    private bool isOpen=false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Interact()
    {
        if (!isOpen)
        {
            animator.SetBool("Open", true);
            animator.SetBool("CLose", false);
            AudioManager.Instance.PlayOneShot(FmodEvents.Instance.doorOpenClose, this.transform.position);
        }else if(isOpen)
        {
            animator.SetBool("Close", true);
            animator.SetBool("Open", false);
            AudioManager.Instance.PlayOneShot(FmodEvents.Instance.doorOpenClose, this.transform.position);
        }
        
    }

    
}
