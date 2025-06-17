using Unity.VisualScripting;
using UnityEngine;

// Title: Add a sound effect manager to your game- 2D platformer Unity #26
// Author: Game Code Library
// Date: 16 February 2024
// Code version: Unknown
// Availability: https://youtu.be/rAX_r0yBwzQ?si=E9eu7PGWc_ng1Hpc

public class SoundEffectManager : MonoBehaviour
{
    //To call sounds go to the specifc script, add SoundEffectManager.Play("SoundName") 
    private static SoundEffectManager Instance; //Callable from anywhere
    private static AudioSource audioSource;
    private static AudioSource softerAudioSource; //For enemy sound effects
    private static SoundEffectLibrary soundEffectLibrary;
    private void Awake() //Allows there to be only one script
    {
        if (Instance == null)
        {
            Instance = this;
            AudioSource[] audioSources = GetComponents<AudioSource>();
            audioSource = audioSources[0]; //First in the list, dont touch
            softerAudioSource = audioSources[1];
            soundEffectLibrary = GetComponent<SoundEffectLibrary>(); // gets the other script
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Play(string soundName, bool softerSound = false)
    {
        AudioClip audioClip = soundEffectLibrary.GetRandomClip(soundName);
        if (audioClip != null) //Not null
        {
            if (softerSound)
            {
                softerAudioSource.pitch = Random.Range(0.89f, 0.95f);
                softerAudioSource.PlayOneShot(audioClip);
            }
            else
            {
                audioSource.PlayOneShot(audioClip);
            }
        }
        else
        {
            Debug.Log("Clip Not Found");
        }
    }

    public static void PlayEnemy(string soundName, bool softerSound = false)
    {
        AudioClip audioClip = soundEffectLibrary.GetRandomClip(soundName);
        if (audioClip != null) //Not null
        {
            if (softerSound)
            {
                softerAudioSource.pitch = Random.Range(0.89f, 0.95f);
                softerAudioSource.PlayOneShot(audioClip);
            }
            else
            {
                audioSource.PlayOneShot(audioClip);
            }
        }
        else
        {
            Debug.Log("Clip Not Found");
        }
    }
}
