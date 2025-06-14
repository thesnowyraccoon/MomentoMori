using System.Collections;
using UnityEngine;
using TMPro;
using static UnityEngine.Rendering.DebugUI.Table;
using Unity.VisualScripting;
using UnityEngine.Playables;

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
    [SerializeField] private DialogueObject playDialogue;
    [SerializeField] private TMP_Text inputPromptText;
    [SerializeField] private MonoBehaviour PlayerController;
    [SerializeField] private PlayableDirector Cutscene;
    [SerializeField] private PlayableDirector Cutscene2;
    [SerializeField] private PlayableDirector Cutscene3;
    [SerializeField] private PlayableDirector Cutscene4;
    private int currentDialogueIndex = 0;


    private TypewriterEffect typewriterEffect;

    private void CloseDialogueBox()
    {
        PlayerController.enabled = true;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }

    private void Start()
    { 
        Cutscene.gameObject.SetActive(false);
        Cutscene2.gameObject.SetActive(false);
        Cutscene3.gameObject.SetActive(false);
        Cutscene4.gameObject.SetActive(false);
        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogueBox();
        ShowDialogue(playDialogue);
        inputPromptText.text = "";

    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        PlayerController.enabled = false;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        while (currentDialogueIndex < dialogueObject.Dialogue.Length)
        {
            string dialogue = dialogueObject.Dialogue[currentDialogueIndex];
            yield return typewriterEffect.Run(dialogue, textLabel);

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

            if (currentDialogueIndex == 1)
            {
                Cutscene.gameObject.SetActive(true);

                Cutscene.Play();
                yield return new WaitUntil(() => Cutscene.state != PlayState.Playing);

                Cutscene.gameObject.SetActive(false);
            }

            else if (currentDialogueIndex == 11)
            { 
                Cutscene4.gameObject.SetActive(true);

                Cutscene4.Play();
                yield return new WaitUntil(() => Cutscene4.state != PlayState.Playing);

                Cutscene4.gameObject.SetActive(false);

                yield return new WaitForSeconds(1);
            }

            else if (currentDialogueIndex == 14)
            {
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                CloseDialogueBox();
                inputPromptText.text = "WASD to move around";

                bool wPressed = false, aPressed = false, sPressed = false, dPressed = false;

                while (!(wPressed && aPressed && sPressed && dPressed))
                {
                    if (Input.GetKeyDown(KeyCode.W)) wPressed = true;
                    if (Input.GetKeyDown(KeyCode.A)) aPressed = true;
                    if (Input.GetKeyDown(KeyCode.S)) sPressed = true;
                    if (Input.GetKeyDown(KeyCode.D)) dPressed = true;

                    yield return null;
                }
                inputPromptText.text = "";

                PlayerController.enabled = false;
                dialogueBox.SetActive(true);
            }

            else if (currentDialogueIndex == 19)
            {
                dialogueBox.SetActive(false);
                Cutscene2.gameObject.SetActive(true);
                Cutscene2.Play();

                yield return new WaitUntil(() => Cutscene2.state != PlayState.Playing);
                Cutscene2.gameObject.SetActive(false);
                PlayerController.enabled = true;
                inputPromptText.text = "Pick up tarot card";

                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));

                dialogueBox.SetActive(true);
                inputPromptText.text = "";
                PlayerController.enabled = false;
            }

            else if (currentDialogueIndex == 21)
            {
                dialogueBox.SetActive(false);
                Cutscene3.gameObject.SetActive(true);
                Cutscene3.Play();

                yield return new WaitUntil(() => Cutscene3.state != PlayState.Playing);
                Cutscene3.gameObject.SetActive(false);
                PlayerController.enabled = true;

                inputPromptText.text = "Press 'k' to Attack";

                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.K));
                CloseDialogueBox();
                PlayerController.enabled = false;

                dialogueBox.SetActive(true);
                inputPromptText.text = "";
            }

            currentDialogueIndex++;
        }
        
        CloseDialogueBox();
    }
}
