using UnityEngine;

// Title: How to make a BOSS in Unity!
// Author: Brackeys
// Date: January 26 2020
// Code version: Unknown
// Availability: https://youtu.be/AD4JIXQDw0s?si=6hfV5X20wXlI3O14

public class Boss_Idle : StateMachineBehaviour
{
    float timer;
    float cooldown;
    float randomAttack;

    BossController boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<BossController>();
        cooldown = boss.attackCooldown;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        if (timer > cooldown)
        {
            timer = 0;

            randomAttack = Random.Range(1, 3);

            if (randomAttack == 1)
            {
                animator.SetTrigger("Head");
                SoundEffectManager.Play("HeadSpin");
            }
            else if (randomAttack == 2)
            {
                animator.SetTrigger("Wing");
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Head");
        animator.ResetTrigger("Wing");
    }
}