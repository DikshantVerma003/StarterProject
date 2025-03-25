using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // Assign the Action Figure in Inspector
    public float attackRange = 1.5f; // Distance at which enemy attacks
    public float attackRate = 1f; // Attacks per second
    public int damage = 10; // Damage per attack

    private NavMeshAgent agent;
    private float nextAttackTime = 0f;
    private ActionFigureHealth actionFigureHealth;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        actionFigureHealth = target.GetComponent<ActionFigureHealth>();
    }

    void Update()
    {
        if (target == null) return;

        // Move towards the action figure
        agent.SetDestination(target.position);

        // Check distance for attack
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= attackRange && Time.time >= nextAttackTime)
        {
            AttackTarget();
            nextAttackTime = Time.time + 1f / attackRate; // Cooldown for next attack
        }
    }

    void AttackTarget()
    {
        if (actionFigureHealth != null)
        {
            actionFigureHealth.TakeDamage(damage);
        }
    }
}
