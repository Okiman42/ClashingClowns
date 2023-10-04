using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control the character's movement speed.

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Character 1 movement (using "A" and "D" keys).
        if (gameObject.tag == "Character1")
        {
            float horizontalInput = Input.GetAxis("Horizontal1");

            Vector2 newVelocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
            rb.velocity = newVelocity;
        }
        // Character 2 movement (using "UpArrow" and "DownArrow" keys).
        else if (gameObject.tag == "Character2")
        {
            float horizontalInput = Input.GetAxis("Horizontal2");

            Vector2 newVelocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
            rb.velocity = newVelocity;
        }
    }
}
