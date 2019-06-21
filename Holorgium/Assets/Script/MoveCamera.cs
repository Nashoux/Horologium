using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MoveCamera : MonoBehaviour
{

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

    void Update()
    {
        
    }
}
