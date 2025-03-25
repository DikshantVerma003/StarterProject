using UnityEngine;
using UnityEngine.UI;

public class ActionFigureHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    [SerializeField] private Text healthText; // Assign a UI Text element in the Inspector

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }

    void Die()
    {
        Destroy(gameObject); // Destroy the Action Figure when health reaches 0
    }
}
