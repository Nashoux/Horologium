using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMecanism : MonoBehaviour{

    LayerMask mask;
    void Start(){
        mask = LayerMask.GetMask("Obstacles");
    }

    void Update(){

        
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray,out hitInfo, Mathf.Infinity, mask ) && hitInfo.collider.tag == "Gears"){
            if(Input.GetMouseButtonDown(1)){
                
            }
        }
    }
}