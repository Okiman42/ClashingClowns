using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control the character's movement speed.

    private Rigidbody2D rb;
    private Transform characterTransform;
    private bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        characterTransform = transform; // Cache the Transform component.
    }

    private void Update()
    {

        // Character 1 movement (using "A" and "D" keys).
        if (gameObject.tag == "Character1")
        {
            float horizontalInput = Input.GetAxis("Horizontal1");

            Vector2 newVelocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
            rb.velocity = newVelocity;

            FlipSprite(horizontalInput);
        }
        // Character 2 movement (using "UpArrow" and "DownArrow" keys).
        else if (gameObject.tag == "Character2")
        {
            float horizontalInput = Input.GetAxis("Horizontal2");

            Vector2 newVelocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
            rb.velocity = newVelocity;

            FlipSprite(horizontalInput);
        }

    }

    private void FlipSprite(float horizontalInput)
    {
        // If the character is moving right but not facing right, or moving left but not facing left, flip the sprite.
        if ((horizontalInput > 0 && !facingRight) || (horizontalInput < 0 && facingRight))
        {
            // Toggle the boolean for facing direction.
            facingRight = !facingRight;

            // Calculate the new X-scale with a negative sign if moving left, or positive if moving right.
            Vector3 newScale = characterTransform.localScale;
            newScale.x *= -1;
            characterTransform.localScale = newScale;
        }
    }

}
