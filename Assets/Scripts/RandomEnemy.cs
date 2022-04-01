using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomEnemy : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject[] AllUnkoman;
    private int target;

    //Rigidbody rb;
    [SerializeField]
    Animator anima;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        AllUnkoman = GameObject.FindGameObjectsWithTag("Obs");
        target = UnityEngine.Random.Range(0, AllUnkoman.Length);
       // rb = this.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obs")
        {
            target = UnityEngine.Random.Range(0, AllUnkoman.Length);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // target = UnityEngine.Random.Range(0, AllUnkoman.Length);
        anima.SetBool("Run", true);
        agent.destination = AllUnkoman[target].transform.position;
       // Debug.Log(target);
    }
}
