using System.Collections;
using UnityEngine;
using TMPro;

//Title: TYPING EFFECT: How to Create a Flexible Dialogue System #2 (Unity)
//Author: Semag Games
//Date: 10 June 2025
//Platform: Youtube
//Code version: Unknown
//Availability: https://youtu.be/C5xnB1dZA_w?si=aj9_x5HCsiioF7bW

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private float typewriterSpeed = 50f;

    public Coroutine Run(string textToType, TMP_Text textLabel, AudioClip sound) 
    {
      return StartCoroutine(TypeText(textToType, textLabel, sound));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel, AudioClip sound)
    {
        textLabel.text = string.Empty;

        foreach (char letter in textToType)
        {
            textLabel.text += letter;

            // Play the sound for each character
            if (sound != null)
                SoundManager.instance.PlaySound(sound);

            yield return new WaitForSeconds(1f / typewriterSpeed);
        }

        textLabel.text = textToType;
  
    }
}
