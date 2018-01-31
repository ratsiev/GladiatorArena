using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour {

    public float currentSpeed;
    public float rotateSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float speedMultiplier = 1.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Animator animator;
    private const float walkSpeed = 5.5f;
    private const float runSpeed = 10.0f;

    private void Start() {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        
        if (controller.isGrounded) {
            currentSpeed = Input.GetButton("Run") ? runSpeed : Input.GetAxis("Vertical") != 0 ? walkSpeed : 0;
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= currentSpeed * speedMultiplier;
            moveDirection.y = Input.GetButton("Jump") ? jumpSpeed : moveDirection.y - gravity * Time.deltaTime;
        }
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        animator.SetBool("Jumping", !controller.isGrounded);
        animator.SetFloat("Speed", currentSpeed);
    }
}
