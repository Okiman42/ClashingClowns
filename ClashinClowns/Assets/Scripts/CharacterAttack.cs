using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public LayerMask targetLayer; // Adjust this to define which layers represent the enemy characters.

    private string myTag; // Store the tag of the current character.

    private void Start()
    {
        myTag = gameObject.tag; // Get the tag of the current character.
    }

    private void Update()
    {
        if (gameObject.tag == "Character1" && Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        // For Player 2 (Character2)
        if (gameObject.tag == "Character2" && Input.GetKeyDown(KeyCode.RightControl)) // Use a different key like "Return" for Player 2.
        {
            Attack();
        }
    }

    // Function to perform the character's attack.
    private void Attack()
    {
        // Cast a ray forward to detect if there's an enemy character in front.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f, targetLayer);

        if (hit.collider != null)
        {
            // Get the tag of the hit character and compare it with the current character's tag.
            string hitTag = hit.collider.gameObject.tag;

            if (hitTag != myTag)
            {
                // Get the CharacterHealth component of the hit character and deal damage to them.
                CharacterHealth enemyHealth = hit.collider.GetComponent<CharacterHealth>();

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage();
                }
            }
        }
    }
}
