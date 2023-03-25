using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool isSprinting;
    private bool isCrouching;

    private bool lerpCrouch;

    private float crouchTimer;

    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 1.2f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        CrouchLogic();
    }

    // receive input for InputManager.cs and apply it to the character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        GravityLogic();

        controller.Move(playerVelocity * Time.deltaTime);

    }

    // TODO: Hold jump to jump higher
    public void Jump()
    {
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
    }

    public void Crouch()
    {
        isCrouching = !isCrouching;
        crouchTimer = 0f;
        lerpCrouch = true;
    }

    public void Sprint(bool isActive)
    {
        isSprinting = isActive;
        if(isActive)
            speed = 8;
        else
            speed = 5;
    }

    private void CrouchLogic()
    {
        if(!lerpCrouch)
            return;
        crouchTimer += Time.deltaTime;
        float p = crouchTimer / 1;
        p *= p;
        if(isCrouching)
            controller.height = Mathf.Lerp(controller.height, 1, p);
        else
            controller.height = Mathf.Lerp(controller.height, 2, p);

        if(p > 1)
        {
            lerpCrouch = false;
            crouchTimer = 0f;
        }
    }

    private void GravityLogic()
    {
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
    }
}
