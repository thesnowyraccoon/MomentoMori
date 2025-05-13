using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Title: Player Health System #2: Heart Display UI (Unity Tutorial)
// Author: Night Run Studio
// Date: April 18 2022
// Code version: Unknown
// Availability: https://youtu.be/uqGkNTFzYXM?si=GgB4EGKlyMtqmOPE

public class HealthUI : MonoBehaviour
{
    // Player Stats
    public PlayerController player;
    private int health;
    private int maxHealth;

    public Sprite emptyStar;
    public Sprite quarterStar;
    public Sprite halfStar;
    public Sprite threequarterStar;
    public Sprite fullStar;
    public Image[] stars;

    void Update()
    {
        health = player.playerHealth;
        maxHealth = player.maxHealth;

        int maxCount = 0;

        if (maxHealth == 50)
        {
            maxCount = 5;
        }
        else if (maxHealth == 40)
        {
            maxCount = 4;
        }
        else if (maxHealth == 30)
        {
            maxCount = 3;
        }
        else if (maxHealth == 20)
        {
            maxCount = 2;
        }
        else if (maxHealth == 10)
        {
            maxCount = 1;
        }

        float healthCheck = health/maxCount;
        int maxCheck = maxHealth/maxCount;

        for (int i = 0; i < stars.Length; i++)
        {
            if (healthCheck == maxCheck)
            {
                stars[i].sprite = fullStar;
            }
            else if (healthCheck > (maxCheck/2))
            {
                stars[i].sprite = threequarterStar;
            }
            else if (healthCheck == (maxCheck/2))
            {
                stars[i].sprite = halfStar;
            }
            else if (healthCheck < (maxCheck/2))
            {
                stars[i].sprite = quarterStar;
            }
            else if (healthCheck == 0)
            {
                stars[i].sprite = emptyStar;
            }

            if (i < maxCount)
            {
                stars[i].enabled = true;
            }
            else
            {
                stars[i].enabled = false;
            }
        }
    }
}
