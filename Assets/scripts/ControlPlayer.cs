using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlPlayer : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public CinemachineVirtualCamera CM_cam;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    float CM_Noise_Amplitude = .5f;
    float CM_Noise_Frequency = .01f;
    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = playerCamera.transform.TransformDirection(Vector3.forward);
        Vector3 right = playerCamera.transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        CM_cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = CM_Noise_Frequency;
        CM_cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = CM_Noise_Amplitude;
        if (curSpeedX > 0 || curSpeedY > 0)
        {
           CM_Noise_Amplitude = CM_Noise_Amplitude >= 1.5f ? CM_Noise_Amplitude = 1.5f : CM_Noise_Amplitude+= 1f * Time.deltaTime;
           CM_Noise_Frequency = CM_Noise_Frequency >= 0.02f ? CM_Noise_Frequency = 0.02f : CM_Noise_Frequency+=0.01f * Time.deltaTime;

        }
        else
        {
            CM_Noise_Amplitude = CM_Noise_Amplitude <= 0.5f ? CM_Noise_Amplitude =0.5f : CM_Noise_Amplitude -= 1f * Time.deltaTime;
            CM_Noise_Frequency = CM_Noise_Frequency <= 0.01f ? CM_Noise_Frequency = 0.01f : CM_Noise_Frequency -= 0.01f * Time.deltaTime;
        }
        print(CM_cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain);
    }
}
