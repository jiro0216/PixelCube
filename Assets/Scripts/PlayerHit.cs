using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public TMP_Text healthText;
    public Renderer playerRenderer; // Reference to the player's renderer for changing color
    public Color hitColor = Color.red; // The color to change to when hit
    public float hitDuration = 0.2f; // Duration for how long the color stays changed

    private Color originalColor; // Store the original color of the player

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
        originalColor = playerRenderer.material.color; // Store the original color
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Max(currentHealth, 0); // Ensure health doesn't go below 0
        UpdateHealthText();

        // Change the player's color temporarily when hit
        StartCoroutine(ChangeColorForDuration(hitColor, hitDuration));

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthText()
    {
        healthText.text = currentHealth.ToString();
    }

    void Die()
    {
        // Handle player's death (e.g., respawn logic)
    }

    // Coroutine to change the player's color temporarily
    private IEnumerator ChangeColorForDuration(Color newColor, float duration)
    {
        playerRenderer.material.color = newColor;
        yield return new WaitForSeconds(duration);
        playerRenderer.material.color = originalColor; // Restore the original color
    }
}
