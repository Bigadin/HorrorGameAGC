using UnityEngine;
using TMPro;

// Define the interactable interface
public interface IInteractable
{
    void Interact();
}

public class Interacter : MonoBehaviour
{
    [SerializeField] private Transform interactionSource;
    [SerializeField] private float interactionDistance;
    [SerializeField] private TextMeshProUGUI pressE;
    [SerializeField] private float sphereRadius = 0.1f;
    private Color raycolor = Color.red;   

    private void Start()
    {
        pressE.text = "";
    }

    private void Update()
    {
        // Ensure the raycast direction is normalized
        Vector3 rayDirection = interactionSource.forward.normalized;

        // Perform the SphereCast
        if (Physics.SphereCast(interactionSource.position, sphereRadius, rayDirection, out RaycastHit hitInfo, interactionDistance))
        {
            // Check if the hit object has a component that implements the IInteractable interface
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactable))
            {
                // Display the interaction prompt
                pressE.text = "Press E";

                // Check for input to interact
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Call the Interact method on the interactable object
                    interactable.Interact();
                    Debug.Log("Interact");
                }
            }
            else
            {
                // Hide the interaction prompt if no interactable object is hit
                pressE.text = "";
            }
        }
        else
        {
            // Hide the interaction prompt if no object is hit
            pressE.text = "";
        }
        Debug.DrawRay(interactionSource.position, rayDirection * interactionDistance, raycolor);
    }
}
