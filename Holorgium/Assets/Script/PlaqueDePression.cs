using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaqueDePression : MonoBehaviour
{

    public float RotationY;
    public float RotationZ;
    public float PositionZ;


    private void OnTriggerEnter(Collider other) {
        MoveCamera.inPlaque.Invoke(RotationY,RotationZ,PositionZ);
    }
}
