using System.Collections;
using UnityEngine;
using TMPro;
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
    [SerializeField] private GameObject Entity;

    //Audio Reference
    [SerializeField] private AudioClip sound;

    //ActorPortrait reference
    [SerializeField] private GameObject potraitEntity;

    //Tarot Reference
    [SerializeField] private GameObject Tarot;

    //Cutscenes References
    [SerializeField] private PlayableDirector Cutscene;
    [SerializeField] private PlayableDirector Cutscene2;
    [SerializeField] private PlayableDirector Cutscene3;
    [SerializeField] private PlayableDirector Cutscene4;
    [SerializeField] private PlayableDirector Cutscene5;

    //Typewriter Reference
    private TypewriterEffect typewriterEffect;

    //Start dialouge on the first array
    private int currentDialogueIndex = 0;

    [HideInInspector] public bool hasAttacked = false;

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
        Remy.GetComponent<Animator>().SetBool("isMoving", false);

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
        Remy.GetComponent<Animator>().SetBool("isMoving", false);

        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }
    private void CloseDialogueBox()
    {
        //EnablesMovement
        Remy.GetComponent<PlayerController>().moveAction.Enable();
        Remy.GetComponent<Animator>().SetBool("isMoving", true);

        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        yield return new WaitForSeconds(0.3f);

        while (currentDialogueIndex < dialogueObject.Dialogue.Length)
        {
            if (currentDialogueIndex == 1)
            {
                potraitEntity.gameObject.SetActive(true);
            }

            string dialogue = dialogueObject.Dialogue[currentDialogueIndex];
            yield return typewriterEffect.Run(dialogue, textLabel, sound);

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

            //Entity appearence/////////////////////////////////////////////

            if (currentDialogueIndex == 1)
            {
                Cutscene.gameObject.SetActive(true);

                Cutscene.Play();
                yield return new WaitUntil(() => Cutscene.state != PlayState.Playing);

                Cutscene.gameObject.SetActive(false);

            }

            // Potrait activated and deactvated/////////////////////////////////////////

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

            //Entity's anger///////////////////////////////////////////////////////////

            else if (currentDialogueIndex == 11)
            {
                Cutscene4.gameObject.SetActive(true);

                Cutscene4.Play();
                yield return new WaitUntil(() => Cutscene4.state != PlayState.Playing);

                Cutscene4.gameObject.SetActive(false);

                yield return new WaitForSeconds(1);
            }

            //WASD Tutotial///////////////////////////////////////////////////////////

            else if (currentDialogueIndex == 14)
            {
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
                CloseDialogueBox();

                //Enables movement
                Remy.GetComponent<PlayerController>().moveAction.Enable();
                Remy.GetComponent<Animator>().SetBool("isMoving", true);

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
                Remy.GetComponent<Animator>().SetBool("isMoving", false);
            }


            //Potrait activated and deactvated//////////////////////////////////

            else if (currentDialogueIndex == 16)
            {
                potraitEntity.gameObject.SetActive(false);
            }

            else if (currentDialogueIndex == 17)
            {
                potraitEntity.gameObject.SetActive(true);
            }


            //Tarot cutscene and pick up//////////////////////////////////////////

            else if (currentDialogueIndex == 19)
            {
                dialogueBox.SetActive(false);

                Cutscene2.gameObject.SetActive(true);
                Cutscene2.Play();

                yield return new WaitUntil(() => Cutscene2.state != PlayState.Playing);
                Cutscene2.gameObject.SetActive(false);

                //Enables movement
                Remy.GetComponent<PlayerController>().moveAction.Enable();
                Remy.GetComponent<Animator>().SetBool("isMoving", true);


                inputPromptText.text = "Pick up tarot card";

                yield return new WaitUntil(() => Tarot == null);
                dialogueBox.SetActive(true);

                //Disables movement
                Remy.GetComponent<PlayerController>().moveAction.Disable();
                Remy.GetComponent<Animator>().SetBool("isMoving", false);

                inputPromptText.text = "";
            }


            //Flower cutscene and attack//////////////////////////////////////////////

            else if (currentDialogueIndex == 21)
            {
                dialogueBox.SetActive(false);

                Cutscene3.gameObject.SetActive(true);
                Cutscene3.Play();

                yield return new WaitUntil(() => Cutscene3.state != PlayState.Playing);
                Cutscene3.gameObject.SetActive(false);

                //Enables movement
                Remy.GetComponent<PlayerController>().moveAction.Enable();
                Remy.GetComponent<Animator>().SetBool("isMoving", true);

                CloseDialogueBox();
                inputPromptText.text = "Press 'k' to Attack";

                //Enables movement
                Remy.GetComponent<PlayerController>().moveAction.Enable();
                Remy.GetComponent<Animator>().SetBool("isMoving", true);

                yield return new WaitUntil(() => hasAttacked);
                dialogueBox.SetActive(true);

                //Disables movement
                Remy.GetComponent<PlayerController>().moveAction.Disable();
                Remy.GetComponent<Animator>().SetBool("isMoving", false);

                inputPromptText.text = "";
            }

            //Dashing Tutorial/////////////////////////////////////////////////////////////

            else if (currentDialogueIndex == 24)
            {
                dialogueBox.SetActive(false);

                //Enables movement
                Remy.GetComponent<PlayerController>().moveAction.Enable();
                Remy.GetComponent<Animator>().SetBool("isMoving", true);


                inputPromptText.text = "Press 'Space' to dash";

                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                yield return new WaitForSeconds(3);

                dialogueBox.SetActive(true);

                //Disables movement
                Remy.GetComponent<PlayerController>().moveAction.Disable();
                Remy.GetComponent<Animator>().SetBool("isMoving", false);

                inputPromptText.text = "";
            }

            // Potrait activated and deactvated/////////////////////////////////////////

            else if (currentDialogueIndex == 28)
            {
                potraitEntity.gameObject.SetActive(false);
            }

            else if (currentDialogueIndex == 29)
            {
                potraitEntity.gameObject.SetActive(true);
            }

            else if (currentDialogueIndex == 31)
            {
                potraitEntity.gameObject.SetActive(false);
            }

            else if (currentDialogueIndex == 32)
            {
                potraitEntity.gameObject.SetActive(true);
            }

            else if (currentDialogueIndex == 33)
            {
                potraitEntity.gameObject.SetActive(false);
            }

            else if (currentDialogueIndex == 34)
            {
                potraitEntity.gameObject.SetActive(true);
            }

            //Time to go cutscene!
            else if (currentDialogueIndex == 40)
            {
                potraitEntity.gameObject.SetActive(false);
                Cutscene5.gameObject.SetActive(true);
                Cutscene5.Play();

                yield return new WaitUntil(() => Cutscene5.state != PlayState.Playing);
                Cutscene5.gameObject.SetActive(false);

                Entity.gameObject.SetActive(false);

                //Disable box
                dialogueBox.SetActive(false);

                yield return new WaitForSeconds(3);

                //Disables movement
                Remy.GetComponent<PlayerController>().moveAction.Enable();
                Remy.GetComponent<Animator>().SetBool("isMoving", true);

                inputPromptText.text = "Go to the portal";
            }
                currentDialogueIndex++;

        }
        
        CloseDialogueBox();
    }
}
