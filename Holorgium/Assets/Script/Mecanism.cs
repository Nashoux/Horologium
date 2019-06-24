using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanism : MonoBehaviour{

    float timerTurn = 0;

    [SerializeField] Transform player;
    
    bool turning = false;

    Animator an;


    void Start(){
        an = GetComponent<Animator>();
        an.SetBool("Turn", false);
    }

    // Update is called once per frame
    void Update(){

        if(Input.GetKey(KeyCode.A) && Vector3.Distance(transform.position, player.position) < 1.5f ){
            an.SetBool("Turn", true);
            an.SetFloat("Multiplier", 1f);
            timerTurn+=Time.deltaTime*2;
            if(turning){
                GearsScript.MecanismStop.Invoke(this);
                turning = false;
            }
        }else{
            an.SetBool("Turn", true);
            an.SetFloat("Multiplier", -0.5f);
            if(timerTurn > 0 ){
                timerTurn-=Time.deltaTime;
                if(!turning){
                    GearsScript.MecanismWorking.Invoke(this);
                    turning = true;
                }
            }else{
                an.SetBool("Turn", false);
                timerTurn = 0;
                if(turning){
                    GearsScript.MecanismStop.Invoke(this);
                    turning = false;
                }
            }
        }
    }




}
