using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    private PlayerInputs playerInput;
    private PlayerInputs.DePieActions dePie;
    private PlayerMotor motor;
    private PlayerLook mirada;

    void Awake()
    {
        playerInput = new PlayerInputs();
        dePie = playerInput.DePie;

        motor = GetComponent<PlayerMotor>();
        mirada = GetComponent<PlayerLook>();

        dePie.Jump.performed += ctx => motor.Jump();

        dePie.Sprint.started += ctx => motor.Sprint(true); // Activar sprint
        dePie.Sprint.canceled += ctx => motor.Sprint(false); // Desactivar sprint

        dePie.Crouch.performed += ctx => motor.Crouch();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //el playermotor se mueve usando el valor de el movement action
        motor.ProcessMoove(dePie.Movement.ReadValue<Vector2>());


    }
    private void LateUpdate()
    {
        mirada.ProcessLook(dePie.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        dePie.Enable();
    }
    private void OnDisable()
    {
        dePie.Disable();   
    }
}