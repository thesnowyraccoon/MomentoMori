using UnityEngine;

//Week 11 -Enumerations & sound
//Andrea Hayes
//18 May 2025
//Code Version: Unkown
//Availability: Wits DIGA2003A Lecture Slides

public class SoundClips : MonoBehaviour
{
    public AudioClip[] Sounds;
    private AudioSource audiosource;
    public PlayerSound soundtype;

    public enum PlayerSound
    {
        Death, //Audio Clip Titled Death Sound 
        Walking, //Other Clips have not yet been added
        Attack,
        Damage
    }

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void PlaySound(PlayerSound soundtype)
    {
        switch (soundtype)
        {
            case PlayerSound.Death:
                audiosource.PlayOneShot(Sounds[0]);
                break;
            case PlayerSound.Walking:
                audiosource.PlayOneShot(Sounds[1]);
                break;
            case PlayerSound.Attack:
                audiosource.PlayOneShot(Sounds[2]);
                break;
            case PlayerSound.Damage:
                audiosource.PlayOneShot(Sounds[3]);
                break;
        }
    }
    public void PlayAssignedSound()
    {
        PlaySound(soundtype);
    }
    void Update()
    {

    }
}
