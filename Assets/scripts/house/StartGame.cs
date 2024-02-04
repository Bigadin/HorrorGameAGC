using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] Animator LoadSceneAnim;
    [SerializeField] GameObject pressEIndicator;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            pressEIndicator.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                //do what ever sound you want (oppening door)
                LoadSceneAnim.Play("SwitchSceneAnimation");
                StartCoroutine(EnterHouse());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        pressEIndicator.SetActive(false);
    }
    IEnumerator EnterHouse()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
