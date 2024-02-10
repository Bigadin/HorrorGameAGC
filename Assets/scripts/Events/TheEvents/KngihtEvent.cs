using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KngihtEvent : GameEvent
{
    [SerializeField]
    private Transform knightPosition;

    [SerializeField]
    private Transform newKnightPosition;

    [SerializeField] GameObject lights;

    [SerializeField]
    private Animator doorAnimator;
    [SerializeField]
    private Door doorScript;

    public override void ConcreteEvent()
    {
        AudioManager.Instance.StopMusic();
        doorAnimator.SetTrigger("Close");
        doorScript.Setbool(false);
        this.knightPosition.position = newKnightPosition.position;
        this.knightPosition.rotation = newKnightPosition.rotation;
        this.enabled = false;
        lights.SetActive(true);

        StartCoroutine(desableLight());
    }
    IEnumerator desableLight()
    {
        yield return new WaitForSeconds(1);
        lights.SetActive(false);
    }
}
