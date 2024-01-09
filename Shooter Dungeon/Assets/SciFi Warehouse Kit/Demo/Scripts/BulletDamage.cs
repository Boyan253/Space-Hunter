using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private int damage;

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a component that can take damage
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            // Apply damage to the object
            damageable.TakeDamage(damage);

            // Destroy the bullet after hitting
            Destroy(gameObject);
        }
    }
}
