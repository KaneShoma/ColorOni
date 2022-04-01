using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    GameObject[] enemyObjects;
    int enemyNum;

    [SerializeField]
    Text En_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        enemyNum = enemyObjects.Length;

        En_text.text = enemyNum + "êlÇ≈Ç∑ÅI";
    }
}
