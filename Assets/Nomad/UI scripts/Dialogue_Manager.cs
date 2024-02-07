using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Dialogue_Manager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public float textDelay;
    public GameObject dialoguePanel;
    private bool dialogueActive = false;
    private Dictionary<string, string> dialogueDatabase = new Dictionary<string, string>();

    void Start()
    {
        // Hide the dialogue text initially
        dialoguePanel.gameObject.SetActive(false);
        
        // Populate the dialogue database
        PopulateDialogueDatabase();
    }

    void PopulateDialogueDatabase()
    {
        // Example: Adding dialogue lines to the database
        dialogueDatabase.Add("1", "This is the first line of dialogue.");
        dialogueDatabase.Add("2", "This is the second line of dialogue.");
        // Add more lines as needed...
    }

    public void ShowThought(string lineKey)
    {
        // Display the thought corresponding to the provided line key
        if (dialogueDatabase.ContainsKey(lineKey))
        {
            string thought = dialogueDatabase[lineKey];
            dialogueText.text = thought;
            dialoguePanel.gameObject.SetActive(true);
            dialogueActive = true;
            StartCoroutine(DisableTextAfterDelay(textDelay)); // Disable text after 5 seconds
        }
        else
        {
            Debug.LogWarning("Dialogue line key '" + lineKey + "' not found in database.");
        }
    }

    IEnumerator DisableTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        HideThought();
    }
    
    public void HideThought()
    {
        // Hide the thought
        dialoguePanel.gameObject.SetActive(false);
        dialogueActive = false;
    }
}