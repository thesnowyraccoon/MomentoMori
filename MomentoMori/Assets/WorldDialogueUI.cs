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

public class WorldDialogueUI : MonoBehaviour
{
    //UI References
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject playDialogue;
    [SerializeField] private TMP_Text inputPromptText;
    [SerializeField] private GameObject Remy;

    //Audio Reference
    [SerializeField] private AudioClip sound;

    //ActorPortrait reference
    [SerializeField] private GameObject potraitEntity;

    //Tarot Reference
    [SerializeField] private GameObject Insomnium;

    //Cutscenes References
    [SerializeField] private PlayableDirector HomeView;
    [SerializeField] private PlayableDirector InsomniumView;

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
        HomeView.gameObject.SetActive(false);
        InsomniumView.gameObject.SetActive(false);

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
        //Start dialouge
        yield return new WaitForSeconds(0.3f);

        while (currentDialogueIndex < dialogueObject.Dialogue.Length)
        {
            if (currentDialogueIndex == 1)
            {
                potraitEntity.gameObject.SetActive(true);
            }

            if (currentDialogueIndex == 2)
            {
                potraitEntity.gameObject.SetActive(false);
            }

            string dialogue = dialogueObject.Dialogue[currentDialogueIndex];
            yield return typewriterEffect.Run(dialogue, textLabel, sound);

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

            //World view Cutscene/////////////////////////////////////////////

            if (currentDialogueIndex == 3)
            {

                HomeView.gameObject.SetActive(true);

                HomeView.Play();
                yield return new WaitUntil(() => HomeView.state != PlayState.Playing);

                HomeView.gameObject.SetActive(false);

            }

            else if (currentDialogueIndex == 4)
            {
                potraitEntity.gameObject.SetActive(true);
            }

            else if (currentDialogueIndex == 5)
            {
                potraitEntity.gameObject.SetActive(false);
            }

            else if (currentDialogueIndex == 6)
            {
                potraitEntity.gameObject.SetActive(true);
            }


            //Insomnium cutscene//////////////////////////////////////////

            else if (currentDialogueIndex == 7)
            {
                dialogueBox.SetActive(false);

                InsomniumView.gameObject.SetActive(true);
                InsomniumView.Play();

                yield return new WaitUntil(() => InsomniumView.state != PlayState.Playing);
                InsomniumView.gameObject.SetActive(false);

                //Enables movement
                Remy.GetComponent<PlayerController>().moveAction.Enable();
                Remy.GetComponent<Animator>().SetBool("isMoving", true);


                inputPromptText.text = "Go to the insomnium";

                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
                //yield return new WaitUntil(() => Insomnium == null);
                dialogueBox.SetActive(true);

                //Disables movement
                Remy.GetComponent<PlayerController>().moveAction.Disable();
                Remy.GetComponent<Animator>().SetBool("isMoving", false);

                inputPromptText.text = "";
            }

            else if (currentDialogueIndex == 8)
            {
                potraitEntity.gameObject.SetActive(false);
            }

            else if (currentDialogueIndex == 9)
            {
                potraitEntity.gameObject.SetActive(true);
            }

            else if (currentDialogueIndex == 10)
            {
                potraitEntity.gameObject.SetActive(false);
            }

            else if (currentDialogueIndex == 11)
            {
                potraitEntity.gameObject.SetActive(true);
            }

            else if (currentDialogueIndex == 12)
            {
                potraitEntity.gameObject.SetActive(false);
            }

            else if (currentDialogueIndex == 13)
            {
                potraitEntity.gameObject.SetActive(true);
            }

            currentDialogueIndex++;

        }

        CloseDialogueBox();
    }
}

