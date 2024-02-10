using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Password : MonoBehaviour, IInteractable
{
    public TMP_Text pwd_display;
    public string password = "ISAAC";


    [SerializeField]
    private GameObject password_UI;

    [SerializeField]
    private GameObject pressE;

    private ControlPlayer player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlPlayer>();
    }

    public void text(string text)
    {
        if (pwd_display.text.Length <= 5)
        {
            pwd_display.text += text;
            Debug.Log(pwd_display.text);
        }
    }

    public void clear()
    {
        pwd_display.text = "";
    }

    public void CheckPassword()
    {
        if (pwd_display.text == password)
        {
            Debug.Log('C');
            pwd_display.text = "CORRECT!";
            // Add animations here
            // ...
            pwd_display.text = "";

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Camera.main.GetComponent<CinemachineBrain>().enabled = true;
            pressE.SetActive(true);
            player.enabled = true;
            Time.timeScale = 1f;
            password_UI.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log('W');
            pwd_display.text = "INCORRECT!";
            pwd_display.text = "";
        }
    }

    IEnumerator DisableTextAfterDelay(float delay)
    {
        Debug.Log('D');
        yield return new WaitForSeconds(delay);
        pwd_display.text = "";
    }

    public  void Interact()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
        pressE.SetActive(false);

        AudioManager.Instance.PlayOneShot(FmodEvents.Instance.papperPickup, this.transform.position);
        password_UI.SetActive(true);
        player.enabled = false;
        Time.timeScale = 0f;
    }
}
