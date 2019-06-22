using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character_Controler : MonoBehaviour
{
    public float speed = 1f;
    private CharacterController controller;
    private Vector3 movementDirection = Vector3.zero;

    bool CamJustMoved = false;

    float multiplier =1;
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleInput();
        controller.SimpleMove(movementDirection * speed);
    }

    void HandleInput()
    {
        float h = Input.GetAxis("Horizontal")*multiplier;
        float v = Input.GetAxis("Vertical")*multiplier;

        if(MoveCamera.CamMouving){
            h =0;
            v=0;
            if(!CamJustMoved){
                multiplier = - multiplier;
                CamJustMoved = true;
            }
        }
        else{
            CamJustMoved = false;
        }

        movementDirection = new Vector3(h, 0f, v);
        movementDirection.Normalize();
        transform.rotation = Quaternion.LookRotation(movementDirection);
    }
}
