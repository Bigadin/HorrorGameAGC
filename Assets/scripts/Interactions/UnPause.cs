using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnPause : MonoBehaviour
{

    public ControlPlayer player;

    public GameObject[] objectsToDeactivate;
    public GameObject menuHolder;
    public GameObject pressE;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlPlayer>();
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Camera.main.GetComponent<CinemachineBrain>().enabled = true;

        pressE.SetActive(true);
        this.gameObject.SetActive(false);
        player.enabled = true;
        
    }
    public void DeactivateAllObjects()
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            Debug.Log("Unpause iiiiiiii");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Camera.main.GetComponent<CinemachineBrain>().enabled = true;

            menuHolder.SetActive(true);
            pressE.SetActive(true);
            DeactivateAllObjects();

            if(transform.GetChild(1).gameObject.activeInHierarchy)
            this.gameObject.SetActive(false);
            player.enabled = true;
            
        }
    }
}
