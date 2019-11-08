using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform playerTrans;
    
    Vector3 tempVec3 = new Vector3();
    Vector3 offset;
    
    void Start()
    {
        offset = transform.position - playerTrans.position;
        tempVec3.y = transform.position.y;
        tempVec3.z = transform.position.z;
    }

    void LateUpdate()
    {
        tempVec3.x = playerTrans.position.x + offset.x;
        transform.position = tempVec3;
    }
}
