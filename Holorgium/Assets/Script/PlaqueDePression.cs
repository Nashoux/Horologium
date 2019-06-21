using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaqueDePression : MonoBehaviour
{

    public float RotationY;
    public float RotationZ;
    public float PositionY;


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && !MoveCamera.CamMouving)
        {
            Debug.Log("1");
            MoveCamera.inPlaque.Invoke(RotationY, RotationZ, PositionY);
        }
    }
}
