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


    //Start Dialogue///////////////////////////////////////////////////////////////
    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        yield return new WaitForSeconds(0.3f);

        while (currentDialogueIndex < dialogueObject.Dialogue.Length)
        {
            if (currentDialogueIndex == 0)
            {
                potraitEntity.gameObject.SetActive(false);
                Debug.Log("We work");
            }

            string dialogue = dialogueObject.Dialogue[currentDialogueIndex];
            yield return typewriterEffect.Run(dialogue, textLabel, sound);

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

            if (currentDialogueIndex == 1)
            {
                potraitEntity.gameObject.SetActive(true);
                Debug.Log("We work 1");
            }

            else if (currentDialogueIndex == 2)
            {
                potraitEntity.gameObject.SetActive(false);
                Debug.Log("We work 2");
            }

            // HomeView /////////////////////////////////////////////

            else if (currentDialogueIndex == 2)
            {
                Cutscene.gameObject.SetActive(true);

                Cutscene.Play();
                yield return new WaitUntil(() => Cutscene.state != PlayState.Playing);

                Cutscene.gameObject.SetActive(false);
                Debug.Log("We work 3");

            }

            // Potrait activated and deactvated/////////////////////////////////////////

            else if (currentDialogueIndex == 4)
            {
                potraitEntity.gameObject.SetActive(true);
                Debug.Log("We work 4");
            }

            else if (currentDialogueIndex == 5)
            {
                potraitEntity.gameObject.SetActive(false);
                Debug.Log("We work 5");
            }


            //Insomnium cutscene and interact//////////////////////////////////////////

            else if (currentDialogueIndex == 6)
            {
                potraitEntity.gameObject.SetActive(true);
                dialogueBox.SetActive(false);

                Cutscene2.gameObject.SetActive(true);
                Cutscene2.Play();

                yield return new WaitUntil(() => Cutscene2.state != PlayState.Playing);
                Cutscene2.gameObject.SetActive(false);

                //Enables movement
                Remy.GetComponent<PlayerController>().moveAction.Enable();
                Remy.GetComponent<Animator>().SetBool("isMoving", true);


                inputPromptText.text = "Go interact with the book";

                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
                dialogueBox.SetActive(true);

                //Disables movement
                Remy.GetComponent<PlayerController>().moveAction.Disable();
                Remy.GetComponent<Animator>().SetBool("isMoving", false);

                inputPromptText.text = "";
                Debug.Log("We work 6");

            }

            // Potrait activated and deactvated/////////////////////////////////////////
            else if (currentDialogueIndex == 7)
            {
                potraitEntity.gameObject.SetActive(false);
                Debug.Log("We work 7");
            }

            else if (currentDialogueIndex == 8)
            {
                potraitEntity.gameObject.SetActive(true);
                Debug.Log("We work 8");
            }

            else if (currentDialogueIndex == 9)
            {
                potraitEntity.gameObject.SetActive(false);
                Debug.Log("We work 9");
            }

            else if (currentDialogueIndex == 10)
            {
                potraitEntity.gameObject.SetActive(true);
                Debug.Log("We work 10");
            }

            else if (currentDialogueIndex == 11)
            {
                potraitEntity.gameObject.SetActive(false);
                Debug.Log("We work 11");
            }

            else if (currentDialogueIndex == 12)
            {
                potraitEntity.gameObject.SetActive(true);
                inputPromptText.text = "Go to bed";
                Debug.Log("We work 12");
            }
        }

        CloseDialogueBox();
        Debug.Log("We work 13");

    }
}

