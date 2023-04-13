using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    [SerializeField] float health = 50f;

    [SerializeField] private Renderer myObject;
    [SerializeField] Material dissolveMat;

    private ZombieAnimator zombieAnimator;
    private NavMeshAgent agent;
    private Animator animator;

    private void Start()
    {
        zombieAnimator = GetComponentInChildren<ZombieAnimator>();
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(float amoout)
    {
        health -= amoout;

        if(health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        agent.isStopped = true;
        zombieAnimator.AnimDie();

        Invoke("DestroyEffect", animator.GetCurrentAnimatorStateInfo(0).length);
    }

    private void DestroyEffect()
    {
        myObject.material = dissolveMat;

        Invoke("DestroyObject", 3f);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
