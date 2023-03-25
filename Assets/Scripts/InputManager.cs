using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    [NonSerialized] public PlayerInput.OnFootActions onFoot;
    [NonSerialized] public PlayerInput.GunActions gunInput;


    private PlayerMotor motor;
    private PlayerLook look;
    public GunSystem gunSystem;

    private void OnEnable() 
    {
        onFoot.Enable();
        // TODO: WHEN A GUN IS EQUIPPED, ENABLE GUNINPUT
        gunInput.Enable();
    }

    private void OnDisable() 
    {
        onFoot.Disable();
        gunInput.Enable();
    }

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        gunInput = playerInput.Gun;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        Subscriptions();
    }

    private void Subscriptions()
    {
        // anytime onFoot.Jump is performed, run motor.Jump()
        onFoot.Jump.performed += ctx => motor.Jump();

        onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.Sprint.performed += ctx => motor.Sprint(true);

        gunInput.Shoot.performed += ctx => gunSystem.ShootCommand(true);
        gunInput.Reload.performed += ctx => gunSystem.ReloadCommand();


        gunInput.Shoot.canceled += ctx => gunSystem.ShootCommand(false);


        onFoot.Sprint.canceled += ctx => motor.Sprint(false);

    }

    private void FixedUpdate()
    {
        // tell the playermotor to move using the value from the movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate() 
    {
        look.ProcessMove(onFoot.Look.ReadValue<Vector2>());
    }

    
}
