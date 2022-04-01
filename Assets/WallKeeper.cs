using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallKeeper : MonoBehaviour
{

    Transform humanTransform;
    Vector3 keeppos;
    Vector3 pos;
    [SerializeField]
    public  bool Zwall;
    [SerializeField]
    public  bool Xwall;    
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (Zwall==true) {
            Debug.Log("ê⁄êG");
            humanTransform = collision.gameObject.transform;
            pos = humanTransform.position;
            keeppos.z = pos.z;
        }else if (Xwall == true)
            {
                Debug.Log("ê⁄êG");
                humanTransform = collision.gameObject.transform;
                pos = humanTransform.position;
                keeppos.x = pos.x;
            }
    }
    void OnCollisionStay(Collision collision)
    {
        if (Zwall == true)
        {
            Debug.Log(keeppos.z);
            humanTransform = collision.gameObject.transform;
            Vector3 pos = humanTransform.position;
            pos.z = keeppos.z;
            humanTransform.position = pos;
        }
        if (Xwall == true)
        {
            Debug.Log(keeppos.x);
            humanTransform = collision.gameObject.transform;
            Vector3 pos = humanTransform.position;
            pos.x = keeppos.x;
            humanTransform.position = pos;
        }

    }
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("ó£íE");
    }
}


