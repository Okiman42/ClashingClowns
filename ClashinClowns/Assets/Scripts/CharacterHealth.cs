using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth = 3; // Adjust this to set the maximum health for each character.
    public int damageAmount = 1; // Adjust this to set the damage amount per hit.

    [SerializeField] private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Function to deal damage to the character.
    public void TakeDamage()
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Function to handle character death.
    private void Die()
    {
        // Add any death behavior here, such as playing an animation or disabling the character.
        Debug.Log(gameObject.name + " has died.");

        Destroy(gameObject);
        // Optionally, you can respawn the character or perform other actions as needed.
    }
}
