using UnityEngine;

public class HelloWave : MonoBehaviour
{
    [SerializeField] private Transform target; // Assign the player (VR Rig) in the Inspector
    [SerializeField] private float triggerRange = 3f; // Distance to trigger animation & audio
    [SerializeField] private Animator animator; // Assign Animator in Inspector
    [SerializeField] private string waveAnimation = "Hello_Wave"; // Animation name
    [SerializeField] private string idleAnimation = "Idle"; // Idle animation name
    [SerializeField] private AudioSource audioSource; // Assign AudioSource in Inspector
    [SerializeField] private AudioClip helloAudio; // Assign Hello_Audio in Inspector

    private bool isWaving = false;

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= triggerRange)
        {
            if (!isWaving)
            {
                StartWaving();
                isWaving = true;
            }
        }
        else
        {
            if (isWaving)
            {
                StopWaving();
                isWaving = false;
            }
        }
    }

    void StartWaving()
    {
        if (animator != null)
        {
            animator.Play(waveAnimation);
        }

        if (audioSource != null && helloAudio != null)
        {
            audioSource.PlayOneShot(helloAudio);
        }
    }

    void StopWaving()
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
