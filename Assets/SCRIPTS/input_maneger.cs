using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class input_maneger : MonoBehaviour
{
    public  NewControls playerInput;
    public NewControls.OnFootActions onfoot;
    private player_motor motor;
    private player_look look;
    
    void Awake()
    {
        playerInput = new NewControls();
        onfoot= playerInput.OnFoot;
        motor = GetComponent<player_motor>();
        look = GetComponent<player_look>();
        onfoot.Jump.performed += ctx => motor.Jump();
        onfoot.crouch.performed += ctx => motor.crouch();
        onfoot.sprint.performed += ctx => motor.sprint();
    }

   
    private void FixedUpdate() {
        motor.Process_move(onfoot.movement.ReadValue<Vector2>());
        
    }
    private void LateUpdate() {
        look.process_look(onfoot.look.ReadValue<Vector2>());
    }
    private void  OnEnable() {
        onfoot.Enable();
    }
    private void OnDisable() {
        onfoot.Disable();
        }
}
