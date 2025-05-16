using System;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
   public Message[] messages; //Assign Messgaes in the inspector
   public Actor [] actors; //Assign Characters in the Inspector

   public void StartDialogue() {
    FindObjectsByType<DialogueManager>().OpenDialogue(messages, actors);
   }

    private object FindObjectsByType<T>()
    {
        throw new NotImplementedException(); //This is to make the Find Objects Work
    }
}

[System.Serializable] //This Assigns Different Messages to different charcaters 
public class Message{
    public int actorId;
    public string message;
}

[System.Serializable] //Joins the sprite of the characters and names
public class Actor { 
    public string name; //Not sure if we need this as the names are apart of the sprite
    public Sprite sprite;
}