using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [Header("Misc")]
    private LayerMask m_WhatIsGround;
    private Transform m_GroundCheck;
    private Transform m_CeilingCheck;
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.

    [Header("Movement")]
    public float speed = 3f;
    public float forceMultiplier = 10;
    public float jumpForce = 10f;

    [Header("Outside Objects")]
    public GameObject myBoxGamePrefab;
    Rigidbody2D rb2d;

    [Header("Text Elements")]
    public int points = 0;


    [Header("Events")]
    private bool isGrounded;
    public UnityEvent<int> pointEvent;
    public UnityEvent OnLandEvent;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }


    void FixedUpdate()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
        float moveDirection = Input.GetAxis("Horizontal");
        transform.Translate(moveDirection * speed * Time.deltaTime, 0f, 0f);
        
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    
    IEnumerator ScoreIncreaseRoutine(){
        while(true){
            yield return null;
        }
    }











    

}
