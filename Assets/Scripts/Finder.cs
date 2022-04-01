using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Finder : MonoBehaviour
{
    [SerializeField]
    private Material m_defaultMaterial = null;
    [SerializeField]
    private Material m_foundMaterial = null;

    private Renderer m_renderer = null;
    private List<GameObject> m_targets = new List<GameObject>();

    NavMeshAgent agent;
    GameObject[] AllUnkoman;
    private int target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        AllUnkoman = GameObject.FindGameObjectsWithTag("Obs");
        target = UnityEngine.Random.Range(0, AllUnkoman.Length);
    }

    private void Awake()
    {
        m_renderer = GetComponentInChildren<Renderer>();

        //SearchScriot���Ăяo��
        var searching = GetComponentInChildren<SearchScript>();
        searching.onFound += OnFound;
        searching.onLost += OnLost;
    }

    public void OnChase()
    {
        target = Random.Range(0, AllUnkoman.Length);
    }

    private void OnFound( GameObject i_fundObject)
    {
        m_targets.Add(i_fundObject);
        m_renderer.material = m_foundMaterial;
        /*
        //�v���C���[�Ƌt����������
        //��ɉ�]
        transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime);
        */
    }

    private void OnLost(GameObject i_lostObject)
    {
        m_targets.Remove(i_lostObject);
        if(m_targets.Count == 0)
        {
            m_renderer.material = m_defaultMaterial;
        }
    }

    void Update()
    {
        agent.destination = AllUnkoman[target].transform.position;
        Debug.Log(target);
    }
}
