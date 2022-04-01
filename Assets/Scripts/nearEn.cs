using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nearEn : MonoBehaviour
{
    private GameObject nearObj;         //最も近いオブジェクト

    private float distNum; //最も近いオブジェクトと自分の距離

   

    [SerializeField]
    private GameObject plObj;

    [SerializeField]
    private Image img;
    [SerializeField]
    private Image en_img;
    [SerializeField]
    GameObject plimg;
    [SerializeField]
    GameObject enimg;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

        nearObj = serchTag(plObj, "Enemy");
        distNum = Dist(plObj, "Enemy");

        plimg.transform.position = new Vector3(enimg.transform.position.x-distNum*10,plimg.transform.position.y, plimg.transform.position.z);
        
       // Debug.Log(nearObj.GetComponent<SkinnedMeshRenderer>().material.color+"色の敵との距離は"+distNum.ToString("F2")+"です");
        img.color = nearObj.GetComponent<SkinnedMeshRenderer>().material.color;
        en_img.color = nearObj.GetComponent<SkinnedMeshRenderer>().material.color;
    }
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }

    float Dist(GameObject nowObj, string tagName)
    {
        float tmpdist = 0.0f;//距離変数
        float neardist = 0.0f;//最も近い距離

        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
           
            tmpdist = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            if (neardist == 0 || neardist > tmpdist)
            {
                neardist = tmpdist;
                //nearObjName = obs.name;
                
            }
        }
        return neardist;
    }
}

