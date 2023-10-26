using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowBolt : MonoBehaviour
{
    public int damage = 10; // Damage inflicted by the bolt
    public float lifeDuration = 5.0f; // Time in seconds before the bolt disappears

    private void Start()
    {
        // Set a timer to destroy the bolt after a certain duration
        Destroy(gameObject, lifeDuration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Handle collision with other objects
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Check if the collided object has an "Enemy" tag (you can adjust this tag)
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                // If the collided object has an EnemyHealth component, deal damage to it
                enemyHealth.TakeDamage(damage);
            }

            // Destroy the bolt on impact
            Destroy(gameObject);
        }
        else
        {
            // Destroy the bolt on any other collision
            Destroy(gameObject);
        }
    }
}
