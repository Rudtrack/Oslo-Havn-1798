using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleReset : StateMachineBehaviour
{
    public string[] setTrigger;
    public string[] Triggers;
    public string[] Bools;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.SetTrigger(setTrigger.Length);
        /// Aktiverer alle setTriggers
        for (int i = 0; i < setTrigger.Length; i++)
        {
            animator.SetTrigger(setTrigger[i]);
        }

        /*animator.ResetTrigger(Triggers[0]);
        animator.ResetTrigger(Triggers[1]);
        animator.ResetTrigger(Triggers[2]);
        animator.ResetTrigger(Triggers[3]);*/
        //animator.ResetTrigger(Triggers.Length);
        ///  Resetter alle Triggers[] som er fra 0 og over.
        for (int i = 0; i < Triggers.Length; i++)
        {
            animator.ResetTrigger(Triggers[i]);
        }



        /*animator.SetBool(Bools[0], false);
        animator.SetBool(Bools[1], false);
        animator.SetBool(Bools[2], false*/
        //animator.SetBool(Bools.Length, false);

        /// Setter alle Bools[] til false.
        for (int i = 0; i < Bools.Length; i++)
        {
            animator.SetBool(Bools[i], false);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
