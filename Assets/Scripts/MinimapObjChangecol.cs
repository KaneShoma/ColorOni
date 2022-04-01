using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapObjChangecol : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        MeshRenderer smr = GetComponent<MeshRenderer>();
        Material mat = other.gameObject.GetComponent<Renderer>().material;

        if (other.gameObject.tag == "Switch")
        {
           // Debug.Log("‚Ô‚Â‚©‚Á‚Ä‚Í‚¢‚Ü‚·");
            smr.material.color = mat.color;
        }
    }
}
