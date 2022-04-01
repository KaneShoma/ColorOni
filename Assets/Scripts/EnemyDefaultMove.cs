using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefaultMove : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    float moveX = 0f;
    float moveZ = 0f;
    [SerializeField]
    float ReturnTime = 2.0f;
    float MoveTime = 0f;

    Rigidbody rb;
    [SerializeField]
    Animator anima;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveTime += Time.deltaTime;

        this.rb.velocity = new Vector3(1*speed, 0, 0);
        Debug.Log("^ŽÀ‚É‚µ‚Ü‚µ‚å‚¤");
        anima.SetBool("Run", true);

        if(MoveTime >= ReturnTime) 
        {
            speed = speed * -1;
            transform.Rotate(new Vector3(0, 180, 0));
            MoveTime = 0f;
        }

    }
}
