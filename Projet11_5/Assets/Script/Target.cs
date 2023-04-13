using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    public float health = 50f;

    private ZombieAnimator zombieAnimator;
    private NavMeshAgent agent;

    private void Start()
    {
        zombieAnimator = GetComponentInChildren<ZombieAnimator>();
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

        Debug.Log("Kill");

        /*Destroy(gameObject);*/
    }
}
