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

    // Update is called once per frame
    void Update()
    {
       hMove = Input.GetAxisRaw("Horizontal") * runSpeed;
       animator.SetFloat("Speed", Mathf.Abs(hMove));

       if (Input.GetKeyDown(KeyCode.W))
       {
            jump = true;
       }
    }

    void FixedUpdate ()
    {
        controller.Move(hMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}