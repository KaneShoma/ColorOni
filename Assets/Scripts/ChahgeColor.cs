using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChahgeColor : MonoBehaviour
{
    Material[] materials;
    
     Color swMaterial;

     Material[] _material;           // ���蓖�Ă�}�e���A��.

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
            //Debug.Log(gmo + "�ɓ�����܂���");
            //Debug.Log(mat + "�F�ł�");
        if (other.gameObject.tag == "Switch")
        {
            smr.materials[0].color = mat.color;
            smr.materials[1].color = mat.color;
        }
        if(other.gameObject.tag == "Enemy")
        {
            //Debug.Log("�G�ł�");
            if(smr.materials[0].color == mat.color)
            {
              //�߂܂����Ƃ��̉�
                    //Debug.Log("�ꏏ�Ȃ̂ŏ����܂�");
                    DelCheck = true;
                    //Debug.Log(DelCheck);
                    GameManager.enemyNum -= 1;
                    Destroy(other.gameObject);
                
            }
        }

    }
}
