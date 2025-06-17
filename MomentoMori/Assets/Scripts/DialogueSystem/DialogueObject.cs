using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

//Title: DIALOGUE DATA: How to Create a Flexible Dialogue System #3 (Unity)
//Author: Semag Games
//Date: 10 June 2025
//Platform: Youtube
//Code version: Unknown
//Availability: https://youtu.be/ZvJYb-nxrj8?si=nYZ5KjbNbrUPuNB_


[CreateAssetMenu]
public class DialogueObject : ScriptableObject
{
    //public DialogueActors[] actors;
    //public Sprite[] actorPortrait;

    [Header("Dialogue")]
    [TextArea]
    public string[] dialogue;

    public string[] Dialogue => dialogue;
}
