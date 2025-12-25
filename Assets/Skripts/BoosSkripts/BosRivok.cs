using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BosRivok : StateMachineBehaviour
{
    private Bos bos;
    Transform playerPosition;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bos = animator.GetComponent<Bos>();
        playerPosition = FindObjectOfType<PlayerMovement>().transform;

        float directoinFromPlayer = Vector2.Distance(playerPosition.position, bos.transform.position);
        if (directoinFromPlayer > 15f)
        {
            bos.Dash();
        }
        else
        {
            bos.DashInSide(30f);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    
}
