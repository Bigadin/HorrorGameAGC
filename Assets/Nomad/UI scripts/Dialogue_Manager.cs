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
    [SerializeField]
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
        dialogueDatabase.Add("1", "My car needs gas, I can't start it like this.");
        dialogueDatabase.Add("2", "I should probably follow these lights. Maybe I can find someone who can help me.");
        dialogueDatabase.Add("3", "A manor right here?");
        dialogueDatabase.Add("4", "Why is everything so dark?");
        dialogueDatabase.Add("5", "The stairs are blocked. I should find another way.");
        dialogueDatabase.Add("6", "Where is this music coming from?");
        dialogueDatabase.Add("7", "I should search around the house more.");
        dialogueDatabase.Add("8", "What was that monster? I should really find a way out and quick.");
        dialogueDatabase.Add("9", "I think the monster came out from the stairs. I should check them.");
        dialogueDatabase.Add("10", "I should go check the paintings... probably.");
        dialogueDatabase.Add("11", "I shouldn't go this way, i have to follow the lights");
        dialogueDatabase.Add("12", "Press F to turn on the FlashLight");
        dialogueDatabase.Add("13", "This key should open a door.");
        dialogueDatabase.Add("14", "I got what i needed i should flee now.");
        dialogueDatabase.Add("15", "Is this a baby crying ? i should check it out.");

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