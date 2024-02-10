using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundMeuble : MonoBehaviour
{
    public void PlayStart()
    {
        AudioManager.Instance.InitializeSound(FmodEvents.Instance.startSpawn, this.transform, 1f, 40f);
    }
    public void PlayEnd()
    {
        AudioManager.Instance.InitializeSound(FmodEvents.Instance.finishSpawn, this.transform, 1f, 40f);
    }
}
