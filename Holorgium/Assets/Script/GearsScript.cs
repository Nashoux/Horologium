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

    public List<GearsScript> GearsNextToThis = new List<GearsScript>();
    public Animator an;

    GearsScript ActiveParent;

    void MecanismWork(Mecanism myMec){
        if(myMec == mecanism){
            turning = true;
            an.SetBool("Turn", turning);
            ActiveNextGearsF(turning,this);
        }

    }

    public void ActiveNextGearsF( bool _turning, GearsScript parentGear){
        turning = _turning;
        an.SetBool("Turn", turning);
        if(turning == true){
            ActiveParent = parentGear;
        }
        for(int i = 0; i <GearsNextToThis.Count; i++){
            if(GearsNextToThis[i].turning != turning && GearsNextToThis[i] != ActiveParent ){
                GearsNextToThis[i].ActiveNextGearsF(turning, this);
                GearsNextToThis[i].an.SetFloat("Multiplier", - an.GetFloat("Multiplier"));
            }
        }
    }
    void MecanismStoping(Mecanism myMec){
        if(myMec == mecanism){
            turning = false;
            an.SetBool("Turn", turning);
            ActiveNextGearsF(turning, this);
        }
    }

    private void Start() {
        MecanismWorking += MecanismWork;
        MecanismStop += MecanismStoping;
        //an = GetComponent<Animator>();
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

        /*for (int i = 60; i>0; i--){
            transform.localScale -= toChange;
            yield return new WaitForEndOfFrame();
        }*/

        transform.localScale = new Vector3(0,0,0);
        transform.position = new Vector3(0,-10,0);
        yield return null;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Gears" && !GearsNextToThis.Contains(other.GetComponent<GearsScript>()) ){
            GearsNextToThis.Add(other.GetComponent<GearsScript>());
            if(turning){
                other.GetComponent<GearsScript>().ActiveNextGearsF(turning, this);
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Gears" && GearsNextToThis.Contains(other.GetComponent<GearsScript>()) ){
           GearsNextToThis.RemoveAt( GearsNextToThis.IndexOf(other.GetComponent<GearsScript>()) );
            if(turning){
                other.GetComponent<GearsScript>().ActiveNextGearsF(false, this);
            }
        }
    }
   
}
