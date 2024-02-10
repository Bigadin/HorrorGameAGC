using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFallSound : MonoBehaviour
{
   public void PlaySound()
    {
        AudioManager.Instance.PlayOneShot(FmodEvents.Instance.bodyFall, transform.position);
    }
}
