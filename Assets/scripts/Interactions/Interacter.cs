using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using TMPro;

interface IInteractable {
    public void interact();
}


public class Interacter : MonoBehaviour
{
    [SerializeField]
    private Transform interactionSource;
    [SerializeField]
    private float interactionDistance;
    [SerializeField]
    private TextMeshProUGUI pressE;

    private void Start()
    {
        pressE.text = "";
    }

    private void Update()
    {

        Ray hit = new Ray(interactionSource.position, interactionSource.forward);
        if (Physics.Raycast(hit, out RaycastHit hitInfo, interactionDistance))
        {
            
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interacobj))
            {
                 pressE.text = "press E";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Interact");
                    interacobj.interact();
                }
                
            }
        }
        else
        {
            pressE.text = "";
        }
        
    }
}
