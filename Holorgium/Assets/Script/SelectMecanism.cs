using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMecanism : MonoBehaviour{

    [SerializeField] GameObject inventoryGear;
    Vector3 size;

    bool isPlacing = false;

    LayerMask maskTake;
    LayerMask maskPlace;
    void Start(){
        maskTake = LayerMask.GetMask("Engrenage");
        maskPlace = LayerMask.GetMask("Wall");
    }

    void Update(){

        if(Input.GetKeyDown(KeyCode.E) && inventoryGear != null){
            isPlacing = !isPlacing;
        }

        
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hitInfo;
        if( inventoryGear == null && Physics.Raycast(ray,out hitInfo, Mathf.Infinity, maskTake ) && hitInfo.collider.tag == "Gears"){
            if(Input.GetMouseButtonDown(1) && hitInfo.collider.GetComponent<GearsScript>() ){
                inventoryGear = hitInfo.collider.gameObject;
                size = hitInfo.collider.transform.localScale;
                inventoryGear.GetComponent<GearsScript>().Autodestruction();

            }
        }
        if( inventoryGear != null && isPlacing && Physics.Raycast(ray,out hitInfo, Mathf.Infinity, maskPlace ) && hitInfo.collider.tag == "Wall") {
            inventoryGear.transform.localScale = size;
            inventoryGear.transform.position = hitInfo.point;
            Debug.Log(hitInfo.transform.eulerAngles.z);
            inventoryGear.transform.localEulerAngles = new Vector3(inventoryGear.transform.localEulerAngles.x,hitInfo.transform.localEulerAngles.z-90f,inventoryGear.transform.localEulerAngles.z);

            if(Input.GetMouseButtonDown(0)){
                inventoryGear = null;
                isPlacing = false;
            }
        }
        else if (inventoryGear != null ){
            inventoryGear.transform.localScale = Vector3.zero;
            inventoryGear.transform.position = new Vector3(0,-10,0);
        }


    }
}