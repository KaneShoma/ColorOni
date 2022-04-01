using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nearEn : MonoBehaviour
{
    private GameObject nearObj;         //�ł��߂��I�u�W�F�N�g

    private float distNum; //�ł��߂��I�u�W�F�N�g�Ǝ����̋���

   

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
        
       // Debug.Log(nearObj.GetComponent<SkinnedMeshRenderer>().material.color+"�F�̓G�Ƃ̋�����"+distNum.ToString("F2")+"�ł�");
        img.color = nearObj.GetComponent<SkinnedMeshRenderer>().material.color;
        en_img.color = nearObj.GetComponent<SkinnedMeshRenderer>().material.color;
    }
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //�����p�ꎞ�ϐ�
        float nearDis = 0;          //�ł��߂��I�u�W�F�N�g�̋���
        //string nearObjName = "";    //�I�u�W�F�N�g����
        GameObject targetObj = null; //�I�u�W�F�N�g

        //�^�O�w�肳�ꂽ�I�u�W�F�N�g��z��Ŏ擾����
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //���g�Ǝ擾�����I�u�W�F�N�g�̋������擾
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //�I�u�W�F�N�g�̋������߂����A����0�ł���΃I�u�W�F�N�g�����擾
            //�ꎞ�ϐ��ɋ������i�[
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //�ł��߂������I�u�W�F�N�g��Ԃ�
        //return GameObject.Find(nearObjName);
        return targetObj;
    }

    float Dist(GameObject nowObj, string tagName)
    {
        float tmpdist = 0.0f;//�����ϐ�
        float neardist = 0.0f;//�ł��߂�����

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

