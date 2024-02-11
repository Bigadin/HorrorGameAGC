using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class F : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textF;
    [SerializeField]
    private string textFName;

    private void OnTriggerEnter(Collider other)
    {
        textF.text = textFName;
        
    }

    private void OnTriggerExit(Collider other)
    {
        textF.text = "";
        Destroy(this.gameObject);
    }


}
