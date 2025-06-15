using System.Collections;
using UnityEngine;
using TMPro;
//using UnityEngine.UI;
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
    //UI References
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject playDialogue;
    [SerializeField] private TMP_Text inputPromptText;
    [SerializeField] private GameObject Remy;

    //ActorPortrait reference
    //[SerializeField] private GameObject actorPotraitRemy;
    [SerializeField] private GameObject potraitEntity;

    //PlayerMovement Reference
    //[SerializeField] private MonoBehaviour PlayerController;

    //Cutscenes References
    [SerializeField] private PlayableDirector Cutscene;
    [SerializeField] private PlayableDirector Cutscene2;
    [SerializeField] private PlayableDirector Cutscene3;
    [SerializeField] private PlayableDirector Cutscene4;

    //Typewriter Reference
    private TypewriterEffect typewriterEffect;

    //Start dialouge on the first array
    private int currentDialogueIndex = 0;


    private void Start()
    {
        //Inactive potrait
        potraitEntity.gameObject.SetActive(false);

        //Inactive cutscenes
        Cutscene.gameObject.SetActive(false);
        Cutscene2.gameObject.SetActive(false);
        Cutscene3.gameObject.SetActive(false);
        Cutscene4.gameObject.SetActive(false);

        //Typing effect
        typewriterEffect = GetComponent<TypewriterEffect>();

        //Disables movement
        Remy.GetComponent<PlayerController>().moveAction.Disable();
        Remy.GetComponent<Animator>().SetBool("isMOving", false);

        //show and close dialogue methods
        CloseDialogueBox();
        ShowDialogue(playDialogue);

        //Prompt text set to blank
        inputPromptText.text = "";

        

    }


    public void ShowDialogue(DialogueObject dialogueObject)
    {
        //DisableMovement
        Remy.GetComponent<PlayerController>().moveAction.Disable();
        Remy.GetComponent<Animator>().SetBool("isMOving", false);

        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }
    private void CloseDialogueBox()
    {
        //EnablesMovement
        Remy.GetComponent<PlayerController>().moveAction.Enable();
        Remy.GetComponent<Animator>().SetBool("isMOving", true);

        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        while (currentDialogueIndex < dialogueObject.Dialogue.Length)
        {
            if (currentDialogueIndex == 1)
            {
                potraitEntity.gameObject.SetActive(true);
            }

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

            else if (currentDialogueIndex == 3)
            {
                potraitEntity.gameObject.SetActive(false);
            }

            else if (currentDialogueIndex == 4)
            {
                potraitEntity.gameObject.SetActive(true);
            }


            else if (currentDialogueIndex == 6)
            {
                potraitEntity.gameObject.SetActive(false);
            }

            else if (currentDialogueIndex == 7)
            {
                potraitEntity.gameObject.SetActive(true);
            }

            else if (currentDialogueIndex == 9)
            {
                potraitEntity.gameObject.SetActive(false);
            }

            else if (currentDialogueIndex == 10)
            {
                potraitEntity.gameObject.SetActive(true);
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

                //Enables movement
                Remy.GetComponent<PlayerController>().moveAction.Enable();
                Remy.GetComponent<Animator>().SetBool("isMOving", true);

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
                dialogueBox.SetActive(true);

                //Disables movement
                Remy.GetComponent<PlayerController>().moveAction.Disable();
                Remy.GetComponent<Animator>().SetBool("isMOving", false);
            }

            else if (currentDialogueIndex == 16)
            {
                potraitEntity.gameObject.SetActive(false);
            }

            else if (currentDialogueIndex == 17)
            {
                potraitEntity.gameObject.SetActive(true);
            }

            else if (currentDialogueIndex == 19)
            {
                dialogueBox.SetActive(false);

                Cutscene2.gameObject.SetActive(true);
                Cutscene2.Play();

                yield return new WaitUntil(() => Cutscene2.state != PlayState.Playing);
                Cutscene2.gameObject.SetActive(false);

                //Enables movement
                Remy.GetComponent<PlayerController>().moveAction.Enable();
                Remy.GetComponent<Animator>().SetBool("isMOving", true);


                inputPromptText.text = "Pick up tarot card";

                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));

                dialogueBox.SetActive(true);

                //Disables movement
                Remy.GetComponent<PlayerController>().moveAction.Disable();
                Remy.GetComponent<Animator>().SetBool("isMOving", false);

                inputPromptText.text = "";

            }

            else if (currentDialogueIndex == 21)
            {
                dialogueBox.SetActive(false);

                Cutscene3.gameObject.SetActive(true);
                Cutscene3.Play();

                yield return new WaitUntil(() => Cutscene3.state != PlayState.Playing);
                Cutscene3.gameObject.SetActive(false);

                //Enables movement
                Remy.GetComponent<PlayerController>().moveAction.Enable();
                Remy.GetComponent<Animator>().SetBool("isMOving", true);

                CloseDialogueBox();
                inputPromptText.text = "Press 'k' to Attack";

                //Enables movement
                Remy.GetComponent<PlayerController>().moveAction.Enable();
                Remy.GetComponent<Animator>().SetBool("isMOving", true);


                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.K));
                dialogueBox.SetActive(true);

                //Disables movement
                Remy.GetComponent<PlayerController>().moveAction.Disable();
                Remy.GetComponent<Animator>().SetBool("isMOving", false);

                inputPromptText.text = "";
            }

            else if (currentDialogueIndex == 25)
            {
                potraitEntity.gameObject.SetActive(false);
            }

            else if (currentDialogueIndex == 26)
            {
                potraitEntity.gameObject.SetActive(true);
            }

            else if (currentDialogueIndex == 28)
            {
                potraitEntity.gameObject.SetActive(false);
            }

            else if (currentDialogueIndex == 29)
            {
                potraitEntity.gameObject.SetActive(true);
            }

            else if (currentDialogueIndex == 30)
            {
                potraitEntity.gameObject.SetActive(false);
            }

            else if (currentDialogueIndex == 31)
            {
                potraitEntity.gameObject.SetActive(true);
            }

            else if (currentDialogueIndex == 36)
            {
                potraitEntity.gameObject.SetActive(false);
            }


            currentDialogueIndex++;
        }
        
        CloseDialogueBox();
    }
}
