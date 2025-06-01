using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public PlayerController player;

    private int health;

    // Update is called once per frame
    void Update()
    {   //Death Sound Effect
        //player health values
        health = player.GetHealth();

        if (health <= 0) 
        {
            SoundEffectManager.Play("Death");
            Debug.Log("SoundPlayed");
        }
    }
}
