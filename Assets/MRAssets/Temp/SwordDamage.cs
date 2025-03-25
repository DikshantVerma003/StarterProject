using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    [SerializeField] private int damage = 100; // Adjustable damage value

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has the tag "Monster"
        if (other.CompareTag("Monster"))
        {
            Destroy(other.gameObject); // Destroy the enemy
        }
    }
}
