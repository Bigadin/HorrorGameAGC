using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderDoor : Door
{
    public override void Interact()
    {
        if (GetState() == DoorState.Locked)
        {

            foreach (GameObject item in Inventory.Instance.GetGameObjects())
            {
                if (item.gameObject.name == GetKeyOpener() )// hna zid el id t3 key
                {
                    SetState(DoorState.Unlocked);
                    AudioManager.Instance?.PlayOneShot(FmodEvents.Instance.unlockDoor, this.transform.position);
                    LoadNextScene();
                    break;
                }

            }
            if (GetState() == DoorState.Locked)
            {
                Setbool(false);
                AudioManager.Instance?.PlayOneShot(FmodEvents.Instance.lockedDoor, this.transform.position);
            }

        }

      
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
