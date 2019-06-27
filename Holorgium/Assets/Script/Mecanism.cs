using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanism : MonoBehaviour{

    float timerTurn = 0;

    [SerializeField] Transform player;
    
    bool turning = false;

    Animator an;

    FMOD.Studio.EventInstance sonneBegin;
    FMOD.Studio.EventInstance sonneEnd;
    FMOD.Studio.EventInstance engrenageSound;


    void Start(){
        an = GetComponent<Animator>();
        an.SetBool("Turn", false);

         sonneBegin = FMODUnity.RuntimeManager.CreateInstance ("event:/MouvementHorloge/ActivationMouvement");
         sonneEnd = FMODUnity.RuntimeManager.CreateInstance ("event:/MouvementHorloge/DésactivationMouvement");
         engrenageSound = FMODUnity.RuntimeManager.CreateInstance ("event:/MouvementHorloge/SonDeStateMouvement");
    }

    void Update(){

        if(Input.GetKey(KeyCode.A) && Vector3.Distance(transform.position, player.position) < 1.5f ){
            an.SetBool("Turn", true);
            an.SetFloat("Multiplier", 1f);
            timerTurn+=Time.deltaTime*2;
            if(turning){
                sonneBegin.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                sonneEnd.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                engrenageSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                GearsScript.MecanismStop.Invoke(this);
                turning = false;
            }
        }else{
            an.SetBool("Turn", true);
            an.SetFloat("Multiplier", -0.5f);
            if(timerTurn > 0 ){
                timerTurn-=Time.deltaTime;
                if(!turning){
                    sonneEnd.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    sonneBegin.start();
                    engrenageSound.start();
                    GearsScript.MecanismWorking.Invoke(this);
                    turning = true;
                }
            }else{
                an.SetBool("Turn", false);
                timerTurn = 0;
                if(turning){
                    sonneBegin.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    engrenageSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    sonneEnd.start();
                    GearsScript.MecanismStop.Invoke(this);
                    turning = false;
                }
            }
        }
    }




}
