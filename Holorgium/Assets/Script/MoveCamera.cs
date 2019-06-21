using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MoveCamera : MonoBehaviour
{

    public static bool CamMouving = false;

    public static Action<float,float,float> inPlaque;

    
    void Awake()
    {
        inPlaque += MouvCam;
    }

    void OnDestroy(){
		inPlaque -= MouvCam;
	}

    void MouvCam ( float yRotation, float zRotation, float z){
        
    }

    IEnumerator CoCamMouv( float yRotation, float zRotation, float z){
        float yR = (yRotation - transform.localRotation.y) /120;

        for(int i = 120; i<0 ; i--){
            
        }
        yield return null;
    }



    void Update()
    {
        
    }
}
