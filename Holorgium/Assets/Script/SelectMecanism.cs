using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMecanism : MonoBehaviour{

    [SerializeField] GameObject inventoryGear;
    Vector3 size;

    LayerMask mask;
    void Start(){
        mask = LayerMask.GetMask("Engrenage");
    }

    void Update(){

        
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hitInfo;
        if( inventoryGear == null && Physics.Raycast(ray,out hitInfo, Mathf.Infinity, mask ) && hitInfo.collider.tag == "Gears"){
            if(Input.GetMouseButtonDown(1) && hitInfo.collider.GetComponent<GearsScript>() ){
                inventoryGear = hitInfo.collider.gameObject;
                size = hitInfo.collider.transform.localScale;
                hitInfo.collider.GetComponent<GearsScript>().Autodestruction();
            }
        }
    }
}