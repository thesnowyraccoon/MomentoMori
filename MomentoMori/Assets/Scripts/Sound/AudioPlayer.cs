using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    //The tutorial scene has a game object: SoundEffectManager, this has everything, just copy paste into new scenes
    private PlayerController player; //Refers to the player script (Death Sound)
    private Melatonin melatonin; //Refers to the melatonin script (Pickup Sound)
    private EnemyController enemy; //Refers to the enemies script (Owl laugh)

    private int health;
    private int newHealth;
    private float following;


    // Update is called once per frame
    void Update()
    {   //Death Sound Effect
        //player health values
        health = player.GetHealth();

        if (health <= 0)
        {
            SoundEffectManager.Play("Death");
            //Debug.Log("SoundPlayed");
        }
        //Melatonin pickup Sound Effect

        /*if ()
        {
            SoundEffectManager.Play("Pop");
        }
        else
        {
            Debug.Log("Ahhhhhhh");
        }*/
        //When the owl enemy is following play this sound effect
        //following = enemy.Follow(); Enemy script needs to be unlocked D:
        //  SoundEffectManager.Play("OwlLaugh")

    }
}
