using Cinemachine;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ControlPlayer : MonoBehaviour
{
    [SerializeField]
    private float walkingSpeed = 7.5f, runningSpeed = 11.5f, jumpSpeed = 8.0f, gravity = 20.0f, lookSpeed = 2.0f, lookXLimit = 45.0f;
    public Camera playerCamera;
    public CinemachineVirtualCamera CM_cam;

    [SerializeField]
    private Animator flashlightAnimator;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    // FMOD Footsteps
    private EventInstance footsteps;
    private EventInstance runningSound;
    private bool isWalking;
    private bool isRunning;

    // Added missing variables
    private float CM_Noise_Amplitude = 0.5f;
    private float CM_Noise_Frequency = 0.01f;

    [SerializeField] public Inventory inventory;
    public string scene;

    [SerializeField]
    private GameObject MainMenu;

    [SerializeField] GameObject saveNotif;

    [SerializeField] GameObject loadNotif;

    [SerializeField]
    private GameObject pressE;

    [SerializeField] public EventManager eventManager;

    [HideInInspector]
    public bool canMove = true;

    public enum FLoorType
    {
        Default,
        Grass,
        Wood



    }
    public enum PlayerStat
    {
        normal,
        hiding,
    }
    public static PlayerStat playerStat;
    private FLoorType curentfloor = FLoorType.Default;



    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // FMOD Footsteps Initialization
        footsteps = AudioManager.Instance.CreateInstance(FmodEvents.Instance.footstepsWalkGrass);
        runningSound = AudioManager.Instance.CreateInstance(FmodEvents.Instance.footstepsRunGrass);
        /*walkwood = AudioManager.Instance.CreateInstance(FmodEvents.Instance.footstepsWalkWood);
        runningwood = AudioManager.Instance.CreateInstance(FmodEvents.Instance.footstepsRunWood);*/
        Debug.Log("Footsteps EventInstance: " + footsteps.isValid());
    }

    void Update()
    {
        if (playerStat == PlayerStat.normal)
        {
            HandleMovement();
        }
        HandleMouseLook();
        HandleCameraNoise();
        UpdateSound();
        OpenMenu();

        //TESTING SAVE-LOAD
        if (Input.GetKeyDown(KeyCode.L))
        {
            loadPlayer();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            savePlayer();
        }
    }

    /*private void CheckFloorType(int layer)
    {
        // Compare the layer to determine the floor type
        switch (layer)
        {
            case 6: // Layer for Grass
                curentfloor=FLoorType.Grass;
                break;

            case 7: // Layer for Wood
                curentfloor = FLoorType.Wood;
                break;

            // Add more cases for other floor types as needed

            default:
                break;
        }
    }*/

    void HandleMovement()
    {
        if (!canMove) return;

        Vector3 forward = playerCamera.transform.TransformDirection(Vector3.forward);
        Vector3 right = playerCamera.transform.TransformDirection(Vector3.right);
        isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical");
        float curSpeedY = (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal");
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Check if walking
        if (Mathf.Abs(curSpeedX) > 0 || Mathf.Abs(curSpeedY) > 0 && !isRunning)
        {
            isWalking = true;
            flashlightAnimator.SetBool("IsMoving", true);
        }
        else if (isRunning)
        {
            isWalking = false;
            flashlightAnimator.SetBool("IsMoving", true);
        }
        else
        {
            isWalking = false;
            flashlightAnimator.SetBool("IsMoving", false);
        }

        if (Input.GetButton("Jump") && characterController.isGrounded)
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

        characterController.Move(moveDirection * Time.deltaTime);
    }


    void HandleMouseLook()
    {
        if (!canMove) return;

        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }

    void HandleCameraNoise()
    {
        CM_cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = CM_Noise_Frequency;
        CM_cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = CM_Noise_Amplitude;

        // Adjust amplitude and frequency based on movement
        if (moveDirection.magnitude > 0)
        {
            CM_Noise_Amplitude = Mathf.Clamp(CM_Noise_Amplitude + 1f * Time.deltaTime, 0.5f, 1.5f);
            CM_Noise_Frequency = Mathf.Clamp(CM_Noise_Frequency + 0.01f * Time.deltaTime, 0.01f, 0.02f);
        }
        else
        {
            CM_Noise_Amplitude = Mathf.Clamp(CM_Noise_Amplitude - 1f * Time.deltaTime, 0.5f, 1.5f);
            CM_Noise_Frequency = Mathf.Clamp(CM_Noise_Frequency - 0.01f * Time.deltaTime, 0.01f, 0.02f);
        }
    }

    void UpdateSound()
    {

        if (isWalking)
        {
            PLAYBACK_STATE playbackstate;
            footsteps.getPlaybackState(out playbackstate);

            if (playbackstate.Equals(PLAYBACK_STATE.STOPPED))
            {

                footsteps.start();
            }
        }
        else
        {

            footsteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
        if (isRunning)
        {
            PLAYBACK_STATE playbackstate;
            runningSound.getPlaybackState(out playbackstate);

            if (playbackstate.Equals(PLAYBACK_STATE.STOPPED))
            {

                runningSound.start();
            }

        }
        else
        {

            runningSound.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }

    private void OpenMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && this.enabled)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Camera.main.GetComponent<CinemachineBrain>().enabled = false;
            pressE.SetActive(false);
            MainMenu.SetActive(true);
            this.enabled = false;
            Time.timeScale = 0f;
        }
    }

    public void SaveNotif()
    {
        saveNotif.gameObject.SetActive(true);
        StartCoroutine(DisableTextAfterDelay(2f, saveNotif)); // Disable text after 2 seconds
    }

    public void LoadNotif()
    {
        loadNotif.gameObject.SetActive(true);
        StartCoroutine(DisableTextAfterDelay(2f, loadNotif)); // Disable text after 2 seconds
    }

    IEnumerator DisableTextAfterDelay(float delay, GameObject go)
    {
        yield return new WaitForSeconds(delay);
        HideNotif(go);
    }

    public void HideNotif(GameObject go)
    {
        // Hide the thought
        go.gameObject.SetActive(false);
    }

    public void savePlayer()
    {
        scene = SceneManager.GetActiveScene().name;
        Debug.Log(scene);
        Save_Sys.SavePlayer(this);
        SaveNotif();
    }

    public void loadPlayer()
    {
        PlayerData pd = Save_Sys.LoadPlayer();

        Debug.Log(pd.scene);

        Vector3 pos = new Vector3();
        pos.x = pd.position[0];
        pos.y = pd.position[1];
        pos.z = pd.position[2];
        transform.GetComponent<CharacterController>().enabled = false;
        transform.position = pos;
        transform.GetComponent<CharacterController>().enabled = true;

        Quaternion rot = Quaternion.Euler(pd.rotation[0], pd.rotation[1], pd.rotation[2]);
        transform.rotation = rot;
        scene = SceneManager.GetActiveScene().name;
        if(scene != "TheGamePlay33")
            inventory.SetGameObjects(pd.items);

        eventManager.SetEvents(pd.events);

        LoadNotif();
        //Add new data here...
    }
}