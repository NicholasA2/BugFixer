using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float attackRange = 1.5f; // Range of the melee attack.
    public int attackDamage = 10;    // Amount of damage inflicted per attack.
    public LayerMask enemyLayer;     // Layer mask for identifying enemies.
    public float attackCooldown = 1f; // Cooldown between attacks.

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackCooldown;
            }
        }
    }

    void Attack()
    {
        // Detect enemies in the attack range.
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            // Check if the detected object has an EnemyHealth component.
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                // Deal damage to the enemy.
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

    // Draw a visualization of the attack range in the Unity editor.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
