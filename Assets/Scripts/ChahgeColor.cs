using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChahgeColor : MonoBehaviour
{
    Material[] materials;
    
     Color swMaterial;

     Material[] _material;           // 割り当てるマテリアル.

    public static bool DelCheck = false;

    void Start()
    {
        materials = Resources.LoadAll<Material>("Materials/");
    }


    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {        
            SkinnedMeshRenderer smr = GetComponent<SkinnedMeshRenderer>();
            GameObject gmo = other.gameObject;
            Material mat = other.gameObject.GetComponent<Renderer>().material;
            //Debug.Log(gmo + "に当たりました");
            //Debug.Log(mat + "色です");
        if (other.gameObject.tag == "Switch")
        {
            smr.materials[0].color = mat.color;
            smr.materials[1].color = mat.color;
        }
        if(other.gameObject.tag == "Enemy")
        {
            //Debug.Log("敵です");
            if(smr.materials[0].color == mat.color)
            {
              //捕まえたときの音
                    //Debug.Log("一緒なので消します");
                    DelCheck = true;
                    //Debug.Log(DelCheck);
                    GameManager.enemyNum -= 1;
                    Destroy(other.gameObject);
                
            }
        }

    }
}
