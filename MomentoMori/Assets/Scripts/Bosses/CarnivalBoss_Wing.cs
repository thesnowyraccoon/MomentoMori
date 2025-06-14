using UnityEngine;

public class CarnivalBoss_Wing : StateMachineBehaviour
{
    float randomAttack;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randomAttack = Random.Range(1, 3);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (randomAttack == 1)
        {
            animator.SetTrigger("LeftSwipe");
        }
        else if (randomAttack == 2)
        {
            animator.SetTrigger("RightSwipe");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("LeftSwipe");
        animator.ResetTrigger("RightSwipe");
    }
}
