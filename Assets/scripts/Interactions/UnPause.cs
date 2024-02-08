using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnPause : MonoBehaviour
{
    
    private ControlPlayer player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlPlayer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Camera.main.GetComponent<CinemachineBrain>().enabled = true;
            this.gameObject.SetActive(false);
            player.enabled = true;
            Time.timeScale = 1f;
        }
    }
}
