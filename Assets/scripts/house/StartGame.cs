using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject LoadSceneAnim;
    [SerializeField] GameObject pressEIndicator;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            pressEIndicator.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                //do what ever sound you want (oppening door)
                AudioManager.Instance.PlayOneShot(FmodEvents.Instance.doorOpenClose,transform.position);
                LoadSceneAnim.SetActive(true);
                StartCoroutine(EnterHouse());
                
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        pressEIndicator.GetComponent<TextMeshProUGUI>().text = "Enter Manor -E-";
    }
    IEnumerator EnterHouse()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex +1);

        yield return null;
    }
}
