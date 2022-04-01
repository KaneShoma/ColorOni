using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CubeCl : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 10.0f;
    float x = 0.0f;
    float z = 0.0f;
    public Rigidbody rb;
    [SerializeField]
    Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         x = Input.GetAxis("Horizontal") * speed;
         z = Input.GetAxis("Vertical")*speed;

        Vector3 direction = new Vector3(x, 0, z);

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0,90,0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            transform.Rotate(0, -90, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0, -90, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            transform.Rotate(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Rotate(0, 180, 0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            transform.Rotate(0, -180, 0);
        }
        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(x, 0 ,z);
    }
}
