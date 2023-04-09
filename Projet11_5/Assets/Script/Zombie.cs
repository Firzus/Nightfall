using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
