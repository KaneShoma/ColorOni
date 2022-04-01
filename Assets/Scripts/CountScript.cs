using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScript : MonoBehaviour
{
    [SerializeField]
    float totalCount = 120.0f;

    [SerializeField]

    Text TimeText;

    private SceneChangerScript scenechangerscript;
    // Start is called before the first frame update
    void Start()
    {
        scenechangerscript = GameObject.FindWithTag("SceneManager").GetComponent<SceneChangerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scenechangerscript.check_clear == false)
        {
            totalCount -= Time.deltaTime;
            TimeText.text = "Žc‚èŽžŠÔ:" + totalCount.ToString("F2");
        }
       

        if(totalCount <= 0)
        {
            TimeText.color = new Color(1.0f,0,0,1.0f);
            scenechangerscript.GameOver();
        }
        else
        {
            TimeText.color = new Color(0, 0, 0, 1.0f);
        }
      /*  if (Input.GetKeyDown(KeyCode.R))
        {
            totalCount = 3.0f;
        }*/
    }
}
