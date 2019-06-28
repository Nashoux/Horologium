using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMecanism : MonoBehaviour{

    [SerializeField] GameObject inventoryGear;
    Vector3 size;

    FMOD.Studio.EventInstance PoseSound;
    FMOD.Studio.EventInstance TakeSound;

    [SerializeField] GameObject[] toSpawn;

    bool isPlacing = false;

    LayerMask maskTake;
    LayerMask maskPlace;
    void Start(){
        PoseSound = FMODUnity.RuntimeManager.CreateInstance ("event:/Joueur/EngrenagePosé");
        TakeSound = FMODUnity.RuntimeManager.CreateInstance ("event:/Joueur/EngrenagePris");
        maskTake = LayerMask.GetMask("Engrenage");
        maskPlace = LayerMask.GetMask("Wall");
    }

    void Update(){

        if(Input.GetKeyDown(KeyCode.Alpha0) ){
            inventoryGear = Instantiate<GameObject>( toSpawn[1] );
            size = Vector3.one;
        }
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            inventoryGear = Instantiate<GameObject>( toSpawn[2] );
            size = Vector3.one;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) ){
            inventoryGear = Instantiate<GameObject>( toSpawn[3] );
            size = Vector3.one;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            inventoryGear = Instantiate<GameObject>( toSpawn[4] );
            size = Vector3.one;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4) ){
            inventoryGear = Instantiate<GameObject>( toSpawn[5] );
            size = Vector3.one;
        }

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
                TakeSound.start();
            }
        }
        if( inventoryGear != null && isPlacing && Physics.Raycast(ray,out hitInfo, Mathf.Infinity, maskPlace ) && hitInfo.collider.tag == "Wall") {
            inventoryGear.transform.localScale = size;
            inventoryGear.transform.position = hitInfo.point;
            Debug.Log(hitInfo.transform.eulerAngles.z);
            if(hitInfo.transform.name == "WallBugger"){
                inventoryGear.transform.localEulerAngles = new Vector3(inventoryGear.transform.localEulerAngles.x,hitInfo.transform.localEulerAngles.z+270f,inventoryGear.transform.localEulerAngles.z);
            }else{
                inventoryGear.transform.localEulerAngles = new Vector3(inventoryGear.transform.localEulerAngles.x,hitInfo.transform.localEulerAngles.z+90f,inventoryGear.transform.localEulerAngles.z);
            }

            if(Input.GetMouseButtonDown(0)){
                PoseSound.start();
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