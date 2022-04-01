using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    Transform cameraTrans;
    [SerializeField] Transform playerTrans;

    [SerializeField] Vector3 cameraVec;  //Vector3(0, 1, -1)
    [SerializeField] Vector3 cameraRot;  //Vector3(45, 0, 0)

    void Awake()
    {
        cameraTrans = transform;
        cameraTrans.rotation = Quaternion.Euler(cameraRot);
    }

    void LateUpdate()
    {
        cameraTrans.position = Vector3.Lerp(cameraTrans.position, playerTrans.position + cameraVec, 2.0f * Time.deltaTime);
    }
}
