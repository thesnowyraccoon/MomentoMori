using System.Collections;
using UnityEngine;
using TMPro;
using static UnityEngine.Rendering.DebugUI.Table;
using Unity.VisualScripting;

//Title: SETUP: How to Create a Flexible Dialogue System - Unity #1
//Author: Semag Games
//Date: 10 June 2025
//Platform: Youtube
//Code version: Unknown
//Availability: https://youtu.be/RfLCzDzkvb0?si=9xiLyRcXKOw3eBuX

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;

    
    private TypewriterEffect typewriterEffect;

    private void Start()
    {
       typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogueBox();
        ShowDialogue(testDialogue);
        
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {

        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return typewriterEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);   
        textLabel.text = string.Empty;
    }
}
