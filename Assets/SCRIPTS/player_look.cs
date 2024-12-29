using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class player_look : MonoBehaviour
{
   public Camera cam;
   public float xRotation =0f;
   public float xsensi =30f ;
   public float ysensi =30f;
   public void process_look(Vector2 Input){
        float mousex=Input.x;
        float mouseY=Input.y;
        xRotation -= (mouseY*Time.deltaTime) *ysensi;
        xRotation= Mathf.Clamp(xRotation,-80f,80f);
        cam.transform.localRotation =Quaternion.Euler(xRotation,0,0);
        transform.Rotate(Vector3.up*(mousex*Time.deltaTime)*xsensi);

    
   }
}
