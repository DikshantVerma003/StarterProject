using UnityEngine;

public class EnemyAnimCharacter : MonoBehaviour
{
    [SerializeField] private Transform target; // Assign the player (VR Rig) in the Inspector
    [SerializeField] private float triggerRange = 3f; // Distance to trigger animation & audio
    [SerializeField] private Animator animator; // Assign Animator in Inspector
    [SerializeField] private string attackAnimation = "Attack"; // Animation name
    [SerializeField] private string idleAnimation = "Idle"; // Idle animation name
    [SerializeField] private AudioSource audioSource; // Assign AudioSource in Inspector
    [SerializeField] private AudioClip attackAudio; // Assign attack sound in Inspector

    private bool isAttacking = false;

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= triggerRange)
        {
            if (!isAttacking)
            {
                StartAttackAnimation();
                isAttacking = true;
            }
        }
        else
        {
            if (isAttacking)
            {
                StopAttackAnimation();
                isAttacking = false;
            }
        }
    }

    void StartAttackAnimation()
    {
        if (animator != null)
        {
            animator.Play(attackAnimation);
        }

        if (audioSource != null && attackAudio != null)
        {
            audioSource.PlayOneShot(attackAudio);
        }
    }

    void StopAttackAnimation()
    {
        if (animator != null)
        {
            animator.Play(idleAnimation);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Set the Gizmo color
        Gizmos.color = Color.red;

        // Draw a wire sphere around the enemy to represent the attack range
        Gizmos.DrawWireSphere(transform.position, triggerRange);
    }


}
