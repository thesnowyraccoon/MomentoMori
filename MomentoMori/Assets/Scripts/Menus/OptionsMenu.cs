using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


//Title: SETTINGS MENU in Unity
//Author: Brackeys
//Date: May 17 2025
//Platform: Youtube
//Code version: Unknown
//Availability: https://youtu.be/YOaYQrN1oYQ?si=6gUG9KxjxhXsSC_r

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void SetVolume(float volume)

    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
