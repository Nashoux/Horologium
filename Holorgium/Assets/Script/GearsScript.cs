using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GearsScript : MonoBehaviour
{

    [SerializeField] Mecanism mecanism;

    public static Action<Mecanism> MecanismWorking;

    public static Action<Mecanism> MecanismStop;
    public bool turning =false;

    Animator an;

    void MecanismWork(Mecanism myMec){
        if(myMec == mecanism){
            turning = true;
            an.SetBool("Turn", turning);
        }

    }
    void MecanismStoping(Mecanism myMec){
        if(myMec == mecanism){
            turning = false;
            an.SetBool("Turn", turning);
        }
    }

    private void Start() {
        MecanismWorking += MecanismWork;
        MecanismStop += MecanismStoping;
        an = GetComponent<Animator>();
    }

    private void OnDestroy() {
         MecanismWorking -= MecanismWork;
        MecanismStop -= MecanismStoping;
    }


    public void Autodestruction(){
        StartCoroutine(DestructionAfterATime());
    }

    IEnumerator DestructionAfterATime(){

        Vector3 toChange = transform.localScale / 60;

        for (int i = 60; i>0; i--){
            transform.localScale -= toChange;
            yield return new WaitForEndOfFrame();
        }
        transform.position = new Vector3(0,-10,0);
        yield return null;
    }
   
}
