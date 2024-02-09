using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSound : MonoBehaviour
{
    public void PlayStart()
    {
        AudioManager.Instance.PlayOneShot(FmodEvents.Instance.knifeStart, this.transform.position);
    }
    public void PlayEnd()
    {
        AudioManager.Instance.PlayOneShot(FmodEvents.Instance.knifeEnd,this.transform.position);
    }
}
