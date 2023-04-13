using UnityEngine;
using UnityEngine.AI;

public class ZombieAnimator : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    public void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponentInParent<NavMeshAgent>();
    }

    public void Update()
    {
        float speed = agent.velocity.magnitude / agent.speed;

        if (speed > 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    public void AnimDie()
    {
        animator.SetTrigger("death");
    }
}
