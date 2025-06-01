using Unity.VisualScripting;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    //To call sounds go to the specifc script, add SoundEffectManager.Play("SoundName") 
    private static SoundEffectManager Instance; //Callable from anywhere
    private static AudioSource audioSource;
    private static SoundEffectLibrary soundEffectLibrary;
    private void Awake() //Allows there to be only one script
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
            soundEffectLibrary = GetComponent<SoundEffectLibrary>(); // gets the other script
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Play(string soundName)
    {
        AudioClip audioClip = soundEffectLibrary.GetRandomClip(soundName);
        if (audioClip != null) //Not null
        {
            audioSource.PlayOneShot(audioClip);
        }
    }

}
