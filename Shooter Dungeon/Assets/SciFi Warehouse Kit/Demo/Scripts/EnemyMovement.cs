using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;          // Reference to the player's transform.
    public float moveSpeed = 3f;      // Speed at which the enemy moves.
    public float detectionRange = 10f; // Range at which the enemy detects the player.
    public float shootingRange = 5f;  // Range at which the enemy starts shooting.

    void Update()
    {
        // Check if the player is within detection range
        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            // Rotate towards the player's position
            transform.LookAt(player.position);

            // Move towards the player
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // Check if the player is within shooting range
            if (Vector3.Distance(transform.position, player.position) < shootingRange)
            {
                // Add shooting logic here, e.g., call a Shoot method
                Shoot();
            }
        }
    }

    void Shoot()
    {
        // Implement shooting logic here
        Debug.Log("Enemy is shooting!");
    }
}
