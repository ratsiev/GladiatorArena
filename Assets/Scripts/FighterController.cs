using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour {

    public float currentSpeed;
    public float rotateSpeed = 6.0f;
    public float gravity = 20.0f;
    public float speedMultiplier = 1.0f;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;    
    private Animator animator;
    private const float walkSpeed = 5.5f;
    private const float runSpeed = 10.1f;

    private void Start() {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        
        if (controller.isGrounded) {
            currentSpeed = Input.GetAxis("Vertical") != 0 ? Input.GetButton("Run") ? runSpeed : walkSpeed : 0;
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= currentSpeed * speedMultiplier;
        }

        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        animator.SetFloat("Speed", currentSpeed);
        animator.SetBool("Attacking", Input.GetButton("Fire1"));

    }
}
