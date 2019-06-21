using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MoveCamera : MonoBehaviour{

    public static bool CamMouving = false;

    public static Action<float,float,float> inPlaque;

    
    void Awake(){
        inPlaque += MouvCam;
    }

    void OnDestroy(){
		inPlaque -= MouvCam;
	}

    void MouvCam ( float yRotation, float zRotation, float yPos){
        StartCoroutine(CoCamMouv(yRotation, zRotation, yPos));
    }

    IEnumerator CoCamMouv( float yRotation, float zRotation, float yPos)
    {
        if(transform.eulerAngles.y%360 >= yRotation-5 && transform.eulerAngles.y % 360 <= yRotation+5)
        {
            CamMouving = false;
            yield return null;
        }


        CamMouving = true;
        float yR = (yRotation - transform.eulerAngles.y) /120;

        for(int i = 120; i>0 ; i--){
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + yR, transform.eulerAngles.z);
            yield return new WaitForEndOfFrame();          
        }


        CamMouving = false;

        yield return null;
    }



}
