using UnityEngine;

public class CharacterProximity : MonoBehaviour
{
    [SerializeField] private Transform player; // Assign VR Rig (XR Origin) in Inspector
    [SerializeField] private float triggerDistance = 3f; // Distance to trigger animation & audio

    [SerializeField] private Animator characterAnimator; // Assign Character Animator
    [SerializeField] private AudioSource audioSource; // Assign AudioSource component
    [SerializeField] private AudioClip helloAudio; // Assign Hello_Audio in Inspector

    private bool hasPlayed = false;

    void Update()
    {
        if (player == null) return;

        // Calculate distance between player and character
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= triggerDistance && !hasPlayed)
        {
            PlayHelloAnimation();
            hasPlayed = true; // Prevent re-triggering
        }
        else if (distance > triggerDistance && hasPlayed)
        {
            PlayIdleAnimation();
            hasPlayed = false; // Reset trigger when player leaves
        }
    }

    void PlayHelloAnimation()
    {
        if (characterAnimator != null)
        {
            characterAnimator.Play("Hello_Wave");
        }

        if (audioSource != null && helloAudio != null)
        {
            audioSource.PlayOneShot(helloAudio);
        }
    }

    void PlayIdleAnimation()
    {
        if (characterAnimator != null)
        {
            characterAnimator.Play("Idle");
        }
    }
}
