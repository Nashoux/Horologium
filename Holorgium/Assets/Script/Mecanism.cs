using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanism : MonoBehaviour{

    [SerializeField] Transform player;

    Animator an;

    void Start()
    {
        an = GetComponent<Animator>();
        an.SetBool("Turn", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) && Vector3.Distance(transform.position, player.position) < 1.5f ){
            an.SetBool("Turn", true);
        }else{
            an.SetBool("Turn", false);
        }
    }
}
