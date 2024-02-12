using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject LoadSceneAnim;
    [SerializeField]
    private TextMeshProUGUI eText;
    
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            

            if (Input.GetKeyDown(KeyCode.E))
            {
                //do what ever sound you want (oppening door)
                AudioManager.Instance.PlayOneShot(FmodEvents.Instance.doorOpenClose,transform.position);
                LoadSceneAnim.SetActive(true);
                StartCoroutine(EnterHouse());
                
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            eText.text = "Enter Manor -E-";
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        eText.text = "";
    }
    IEnumerator EnterHouse()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex +1);

        yield return null;
    }
}
