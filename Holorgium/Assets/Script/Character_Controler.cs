using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controler : MonoBehaviour
{
    public float speed = 35f;
    public float speedJump = 5f;
    private CharacterController controller;
    private Vector3 movementDirection = Vector3.zero;

    bool CamJustMoved = false;

    float multiplier =1;

    public Rigidbody rb;

    [SerializeField] Animator an;

    

    private void Start(){
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update(){

        HandleInput();
        /*/if(rb.velocity.y >0){
            rb.velocity -= new Vector3(0,0.5f,0);
        }else
        {
            rb.velocity = new Vector3(rb.velocity.x,0f,rb.velocity.z);
        }
        */

        
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

        if(Input.GetKeyDown(KeyCode.Space) && rb.velocity.y < 0.5f ){
            an.SetTrigger("Jump");
            StartCoroutine(Jumping());
        }

                
        movementDirection.Normalize();
        transform.rotation = Quaternion.LookRotation(movementDirection);
        transform.position += new Vector3(h, 0f, v).normalized*speed/1000;

    }

    IEnumerator Jumping(){
        yield return new WaitForSeconds(0.01f);
        rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y +speedJump, rb.velocity.z ) ;
        yield return null;
    }
}
