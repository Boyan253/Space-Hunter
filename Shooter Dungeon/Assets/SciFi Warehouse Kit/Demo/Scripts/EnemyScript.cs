using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy.
    private int currentHealth; // Current health of the enemy.

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Perform any death-related actions here
        // For example, play death animation, spawn particle effects, etc.
        Destroy(gameObject); // Remove the enemy GameObject
    }
}
