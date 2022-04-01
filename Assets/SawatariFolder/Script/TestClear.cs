using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClear : MonoBehaviour
{
    float count=10f; 
    public int captureenemy = 0;
    [SerializeField]
    public int capturelimit = 5;
    private SceneChangerScript scenemanagerscript;
    private void Start()
    {
        scenemanagerscript =GameObject.FindWithTag("SceneManager").GetComponent<SceneChangerScript>();
    }
    void OnCollisionEnter(Collision collision)
    {
        captureenemy += 1;
        Debug.Log(captureenemy);
        if (captureenemy >= capturelimit)
        {
            scenemanagerscript.StageClear();
        }

    }
    private void Update()
    {
        count -= Time.deltaTime;
       // Debug.Log(count);
        if (count<=-1000) {
            scenemanagerscript.GameOver();
        }
    }
}
