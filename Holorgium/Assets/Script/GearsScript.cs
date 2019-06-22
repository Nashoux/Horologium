using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearsScript : MonoBehaviour
{


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
