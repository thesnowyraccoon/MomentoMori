using System.Collections.Generic;
using UnityEngine;

// Title: Add a sound effect manager to your game- 2D platformer Unity #26
 // Author: Game Code Library
 // Date: 16 February 2024
 // Code version: Unknown
 // Availability: https://youtu.be/rAX_r0yBwzQ?si=E9eu7PGWc_ng1Hpc

public class SoundEffectLibrary : MonoBehaviour
{
    [SerializeField] private SoundEffectGroup[] soundEffectGroups;
    //string = Sound effect name
    private Dictionary<string, List<AudioClip>> soundDictionary;

    private void Awake()
    {
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        soundDictionary = new Dictionary<string, List<AudioClip>>();
        foreach (SoundEffectGroup soundEffectGroup in soundEffectGroups)
        {
            soundDictionary[soundEffectGroup.name] = soundEffectGroup.audioClips;
        }
    }
    public AudioClip GetRandomClip(string name)
    {
        if (soundDictionary.ContainsKey(name))
        {
            List<AudioClip> audioClips = soundDictionary[name];
            if (audioClips.Count > 0)
            {
                return audioClips[Random.Range(0, audioClips.Count)];
            }
        }
        return null;
    }

    [System.Serializable]
    public struct SoundEffectGroup
    {
        public string name;
        public List<AudioClip> audioClips;
    }

}
