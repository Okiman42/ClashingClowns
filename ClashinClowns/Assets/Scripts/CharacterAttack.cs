using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public LayerMask targetLayer; // Adjust this to define which layers represent the enemy characters.

    private string myTag; // Store the tag of the current character.
    private Animator myAnimator; // Reference to the Animator component.

    [SerializeField] GameObject Vfx1;
    [SerializeField] GameObject Vfx2;
    [SerializeField] GameObject VfxBlood;

    ParticleSystem bloodParticles;

    public float cooldownAttack = 0.5f;
    private bool canAttack;
    private float deltaTimeSinceAttack = 0.0f;

 
    public KeyCode keytoset;

    private void Start()
    {
        myTag = gameObject.tag; // Get the tag of the current character.

        myAnimator = GetComponent<Animator>(); // Get the Animator component

        canAttack = true;

        //Vfx1.SetActive(false);
        //Vfx2.SetActive(false);
        //VfxBlood.SetActive(false);

            bloodParticles = VfxBlood.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        Particles();
        

        if (gameObject.tag == "Character1" && Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
            
        }

        // For Player 2 (Character2)
        if (gameObject.tag == "Character2" && Input.GetKeyDown(KeyCode.RightControl)) // Use a different key like "Return" for Player 2.
        {
            Attack();
        }

        if (Input.GetKeyDown(keytoset) && canAttack)
        {

            Debug.Log("did attck");

            //Set cooldown
            deltaTimeSinceAttack = 0.0f;
            canAttack = false;
            /*Vfx1.SetActive(false);
            Vfx2.SetActive(false);*/
            
        }

        if (!canAttack)
        {
            deltaTimeSinceAttack += Time.deltaTime;

            if (deltaTimeSinceAttack >= cooldownAttack)
            {
                canAttack = true;
                Debug.LogWarning("Cooldown done");
                
            }
        }

    }




    // Function to perform the character's attack.
    private void Attack()
    {

        // Play the attack animation by setting the "Attack" trigger.
       // myAnimator.SetTrigger("Attackswipe");
        //myAnimator.Play("attack");

        Vector2 attackDirection = (myTag == "Character2") ? Vector2.left : Vector2.right;

        // Cast a ray in the determined direction to detect if there's an enemy character.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, attackDirection, 1f, targetLayer);
        

        // Attack Particles
        if (gameObject.tag == "Character1" && canAttack)
        {
            Vfx1.GetComponent<ParticleSystem>().Play();
        }
        if (gameObject.tag == "Character2" && canAttack)
        {
            Vfx2.GetComponent<ParticleSystem>().Play();
        }

        if (hit.collider != null)
        {
            // Get the tag of the hit character and compare it with the current character's tag.
            string hitTag = hit.collider.gameObject.tag;

            if (hitTag != myTag)
            {
                // Get the CharacterHealth component of the hit character and deal damage to them.
                CharacterHealth enemyHealth = hit.collider.GetComponent<CharacterHealth>();

                if (canAttack)
                {

                    

                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage();

                        //VfxBlood.SetActive(true);

                        bloodParticles.Play();
                        
                        Debug.Log("blood ");
                        
                    }

                   
                }
                     
            }
        }
    }


    void Particles()
    {
        //if (true)
        {
            //Debug.Log("can attack");
            Debug.LogWarning(canAttack);
            if (Input.GetKeyDown(KeyCode.Space) && canAttack)
            {
                Debug.LogWarning(canAttack);
                //Vfx1.SetActive(true);
                Debug.Log("player 1 particle");
                
            }

            if (Input.GetKeyDown(KeyCode.RightControl) && canAttack)
            {
               // Vfx2.SetActive(true);
                Debug.Log("player 2 particle");
                
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                //Vfx1.SetActive(false);
                //Debug.Log("player 1 particle up");
            }

            if (Input.GetKeyUp(KeyCode.RightControl))
            {
                //Vfx2.SetActive(false);
                //Debug.Log("player 2 particle up");
            }

        }
        
    }

  
}
