using UnityEngine;

//Title: Undertale DIALOGUE|CUTSCENE in Unity (Episode 1)
//Author: Pandemonium
//Date: 16 June 2025
//Platform: Youtube
//Code version: Unknown
//Availability: https://youtu.be/8eJ_gxkYsyY?si=qFw9HtV3AvLjMxDA

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance {  get; private set; }

    private AudioSource source;


    private void Awake()
    {
        instance = this;

        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }
}
