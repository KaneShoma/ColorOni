using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject[] enemyObjects;
    private int enemySum;
    public static int enemyNum;
    [SerializeField]
    Text EnemyText;
    private SceneChangerScript scenechangerscript;

    // Start is called before the first frame update
    void Start()
    {
        enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        enemyNum = enemyObjects.Length;
        enemySum = enemyObjects.Length;
        scenechangerscript = GameObject.FindWithTag("SceneManager").GetComponent<SceneChangerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyText.text = "écÇËÇÃìGÇÕ"+enemyNum.ToString()+"êlÇ≈Ç∑ÅI";
        if (enemyNum<=0) {
            scenechangerscript.StageClear();
        }
    }
}
