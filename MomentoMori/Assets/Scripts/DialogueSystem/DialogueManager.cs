using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage; //Will Display the character icon
    public Text messageText; //Will Display the text
    public RectTransform backgroundBox; //The dialogue box

    //Arrays
    Message[] currentMessages; 
    Actor[] currentActors;
    int activeMessage = 0;

    public void OpenDialogue(Message[] messages, Actor[] actors) { //Calls Back to the DialogueTrigger Script
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;

        Debug.Log("Started Conversation, Loaded Messages" + messages.Length);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
