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

    Rigidbody rb;

    [SerializeField] Animator an;

    

    private void Start(){
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update(){

        HandleInput();

        
    }

    void HandleInput(){

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

        if(h == 0 && v == 0){
            an.SetBool("Walking", false);
        }else
        {
            movementDirection = new Vector3(h, 0f, v);
            an.SetBool("Walking", true);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            an.SetTrigger("Jump");
        }

        
        movementDirection.Normalize();
        transform.rotation = Quaternion.LookRotation(movementDirection);

        rb.velocity = new Vector3(h, 0f, v).normalized*2;

    }
}
