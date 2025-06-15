using UnityEngine;

//Title: HOW TO MAKE AN INTERACTIVE GAME TUTORIAL IN UNITY !
//Author: Blackthornprod
//Date: 12 June 2025
//Platform: Youtube
//Code version: Unknown
//Availability: https://youtu.be/a1RFxtuTVsk?si=Ux8PrUuClWFRK7gc

public class Tutorial : MonoBehaviour
{
    public DialogueObject[] testDialogue;
    private int testDialogueIndex;

    private void Update()
    {
        for (int i = 0; i < testDialogue.Length; i++)
        {
            if (i == testDialogueIndex)
            {
               // testDialogue[testDialogueIndex].SetActive(true);
            }
        }
        if(testDialogueIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) // Moving left and right
            {
                testDialogueIndex++;
            }

            else if (testDialogueIndex == 1)
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyUp(KeyCode.S)) // Mpving Up and Down
                {
                    testDialogueIndex++;
                }
                else if (testDialogueIndex == 2) { }

            }
        }
    }
}
