using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_motor : MonoBehaviour
{
    private CharacterController Controller;
    private Vector3 player_velocity;
    private float player_speed=5f;
    private bool IsGrounded;
    public float gravity= -9.8f;
    public float Jump_height= 3f;
    bool crounching = false;
    float crouchtimer = 1f;
    bool lerpCroucnh = false;
    bool sprinting = false;
    private void Start() {
        Controller = GetComponent<CharacterController>();
        if(Controller==null){
            Debug.Log("f u controller");
        }
    }
    private void Update() {
        IsGrounded=Controller.isGrounded;
        if(lerpCroucnh)
        {
            crouchtimer+= Time.deltaTime;
            float p = crouchtimer/1;
            p*=p;
            if(crounching)
                Controller.height=Mathf.Lerp(Controller.height,1,p);
            else
                Controller.height=Mathf.Lerp(Controller.height,2,p);
            if(p<1)
            {
                lerpCroucnh=false;
                crouchtimer= 0f;
            }
        }
        
    }
    public void Process_move(Vector2 input){
        Vector3 move_direction = Vector3.zero;
        move_direction.x=input.x;
        move_direction.z=input.y;
        Controller.Move(transform.TransformDirection(move_direction)*player_speed*Time.deltaTime);

        player_velocity.y += gravity*Time.deltaTime;
        if(IsGrounded&&player_velocity. y < 0 )

            player_velocity.y=-2f;
        Controller.Move(player_velocity*Time.deltaTime);
        Debug.Log(player_velocity.y);

    }
     public void Jump(){
        if(IsGrounded){
            player_velocity.y = Mathf.Sqrt(Jump_height * -3.0f * gravity);
        }
    }
    public void sprint(){
        sprinting=!sprinting;
        if(sprinting)
            player_speed=8;
        else
            player_speed=5;
    }
    public void crouch(){
        crounching=!crounching;
        crouchtimer=0;
        lerpCroucnh=true;
    }
}
