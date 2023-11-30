using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float attackRange = 1.5f; // Range of the melee attack.
    public int attackDamage = 3;    // Amount of damage inflicted per attack.
    public LayerMask enemyLayer;     // Layer mask for identifying enemies.
    public float attackCooldown = 1f; // Cooldown between attacks.
    float timer = 0f;
    private float nextAttackTime = 0f;
    void Start()
    {
        timer = attackCooldown;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Attack");
                Attack();
                timer = attackCooldown;
            }
        }
    }

    void Attack()
    {
        // Detect enemies in the attack range.
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log(enemy.name);
            // Check if the detected object has an EnemyHealth component.
            Enemy enemyHealth = enemy.GetComponent<Enemy>();
            Debug.Log(enemyHealth);
            if (enemyHealth != null)
            {
                
                // Deal damage to the enemy.
                enemyHealth.ProcessHit(attackDamage);
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
