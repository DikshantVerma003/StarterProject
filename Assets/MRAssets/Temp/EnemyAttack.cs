using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform target; // Assign the target (Player, Action Figure, etc.)
    [SerializeField] private float attackRange = 2f; // Distance to trigger attack
    [SerializeField] private float attackRate = 1f; // Attacks per second
    [SerializeField] private int damage = 10; // Damage per attack
    [SerializeField] private Animator animator; // Assign Animator in Inspector
    [SerializeField] private string attackAnimation = "Attack"; // Name of attack animation

    private float nextAttackTime = 0f;
    private bool isAttacking = false;

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= attackRange)
        {
            if (Time.time >= nextAttackTime)
            {
                AttackTarget();
                nextAttackTime = Time.time + 1f / attackRate; // Cooldown before next attack
            }

            // Keep playing the attack animation if not already playing
            if (!isAttacking)
            {
                animator.Play(attackAnimation);
                isAttacking = true;
            }
        }
        else
        {
            // Stop attack animation when the player leaves the range
            isAttacking = false;
            animator.Play("Idle"); // Replace with your idle animation
        }
    }

    void AttackTarget()
    {
        Debug.Log("Enemy attacked " + target.name);

        // Check if the target has a health component and apply damage
        ActionFigureHealth targetHealth = target.GetComponent<ActionFigureHealth>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Set the Gizmo color
        Gizmos.color = Color.red;

        // Draw a wire sphere around the enemy to represent the attack range
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }



}
