using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript2 : MonoBehaviour
{

    private Transform CamPos;
    private Vector3 Camforward;
    private Vector3 ido;
    private Vector3 Animdir = Vector3.zero;

    [SerializeField]
    Animator anim;

    float runspeed = 0.2f;

    void Start()
    {
       
    }

    void Update()
    {
        if (Camera.main != null)
        {
            CamPos = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        {
            //Debug.Log("wasd�ǂꂩ�̓��͂�����Ă��܂�");
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        if(Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.RightShift))
        {
            runspeed = 0.5f;
        }
        else
        {
            runspeed = 0.2f;
        }
    }

    private void FixedUpdate()
    {
        //�L�[�{�[�h���l�擾�B�v���C���[�̕����Ƃ��Ĉ���
        float h = Input.GetAxis("Horizontal");//��
        float v = Input.GetAxis("Vertical");//�c

        //�J������Transform���擾����Ă�Ύ��s
        if (CamPos != null)
        {
            //2�̃x�N�g���̊e�����̏�Z(Vector3.Scale)�B�P�ʃx�N�g����(.normalized)
            Camforward = Vector3.Scale(CamPos.forward, new Vector3(1, 0, 1)).normalized;
            //�ړ��x�N�g����ido�Ƃ����g�����X�t�H�[���ɑ��
            ido = v * Camforward * runspeed + h * CamPos.right * runspeed;
            //Debug.Log(ido);
        }

        //���݂̃|�W�V������ido�̃g�����X�t�H�[���̐��l������
        transform.position = new Vector3(
        transform.position.x + ido.x/2,
        0,
        transform.position.z + ido.z/2);

        //�����]���pTransform

        Vector3 AnimDir = ido;
        AnimDir.y = 0;
        //�����]��
        if (AnimDir.sqrMagnitude > 0.001)
        {
            Vector3 newDir = Vector3.RotateTowards(transform.forward, AnimDir, 5f * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }

    }

}