using UnityEngine;

public class TestBosII : StateMachineBehaviour
{
    Bos bos;
    public BaseStats stats;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bos = animator.GetComponent<Bos>();
        bos.DirectedBuletAtak(8,32,bos.bulet);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.SetTrigger("rivok");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*
        if ((stats.) < 2500)
        {
            animator.SetTrigger("bosShuting");
            FindObjectOfType<PlayerMovement>().Repulsion(40,bos.transform);
        }
        else animator.SetTrigger("rivok");
        */
    }

    
}
