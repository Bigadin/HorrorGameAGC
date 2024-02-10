using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtsTrigger : MonoBehaviour
{
    [SerializeField]
    private int thoughtNumber;
    private Dialogue_Manager dialogue_manager;
    private void Awake()
    {
        dialogue_manager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<Dialogue_Manager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogue_manager.ShowThought(thoughtNumber.ToString());
        }
    }
}
