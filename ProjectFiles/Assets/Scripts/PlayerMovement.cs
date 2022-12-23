using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterControllerSH controller;
    public Animator playerAnimator;
    public float moveSpeed = 40f;
    float horMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Update() 
    {
        horMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        playerAnimator.SetFloat("Speed", Mathf.Abs(horMove));

        // jump
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }

        // crouch
        if (Input.GetButtonDown("Crouch")) {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")) {
            crouch = false;
        }
    }

    public void OnCrouching(bool isCrouching) 
    {
        playerAnimator.SetBool("isCrouching", isCrouching);
    }

    void FixedUpdate() 
    {
        controller.Move(horMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
