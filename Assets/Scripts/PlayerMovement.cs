using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float hMove = 0f;
    bool jump = false;
    public float runSpeed = 40f;
    [Header("Attack Stuff")]
    public float attackDistance = 1.0f;
    public int damage = 10;
    public float attackCooldown = 1.0f;
    private float lastAttackTime = -999.0f;

    // Update is called once per frame
    void Update()
    {
        hMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(hMove));

        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
        }

        {
            // Check if enough time has passed since last attack
            if (Time.time - lastAttackTime > attackCooldown)
            {
                // Check for space bar tap
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    animator.SetBool("Attack", true);
                    // Set last attack time to current time
                    lastAttackTime = Time.time;


                    // Raycast to find the enemy
                    Ray ray = new Ray(transform.position, transform.right);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, attackDistance))
                    {
                        // Check if the object hit is an enemy
                        if (hit.collider.CompareTag("Enemy"))
                        {
                            // Calculate direction of attack based on A/D key input
                            Vector3 direction = Vector3.zero;
                            if (Input.GetKey(KeyCode.A))
                            {
                                direction = -transform.right;
                            }
                            else if (Input.GetKey(KeyCode.D))
                            {
                                direction = transform.right;
                            }

                            // Calculate position of attack based on direction and attack distance
                            Vector3 attackPosition = transform.position + direction * attackDistance;

                            // Calculate damage to apply to enemy
                            Enemy enemy = hit.collider.GetComponent<Enemy>();
                            if (enemy != null)
                            {
                                enemy.TakeDamage(damage);
                            }

                        }
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        controller.Move(hMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}