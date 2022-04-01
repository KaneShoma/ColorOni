using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;              // �ړ�����
    [SerializeField] private float moveSpeed = 5.0f;        // �ړ����x
    [SerializeField] private float applySpeed = 0.2f;       // �U������̓K�p���x
    private Vector3 latestPos = new Vector3(0, 0, 0);
    private Vector3 diff= new Vector3(0, 0, 0);
    private int start=0;
   

    void Update()
    {
       
        // WASD���͂���AXZ����(�����Ȓn��)���ړ��������(velocity)�𓾂܂�
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            velocity.z += 1;
        
        if (Input.GetKey(KeyCode.A))
            velocity.x -= 1;
        
        if (Input.GetKey(KeyCode.S))
            velocity.z -= 1;
        
        if (Input.GetKey(KeyCode.D))
            velocity.x += 1;
        

        // ���x�x�N�g���̒�����1�b��moveSpeed�����i�ނ悤�ɒ������܂�
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        // �����ꂩ�̕����Ɉړ����Ă���ꍇ
        /*if (velocity.magnitude > 0)
        {
            // �v���C���[�̉�](transform.rotation)�̍X�V
            // ����]��Ԃ̃v���C���[��Z+����(�㓪��)���A�ړ��̔��Ε���(-velocity)�ɉ񂷉�]�Ƃ��܂�
            transform.rotation = Quaternion.LookRotation(-velocity);
        */
            // �v���C���[�̈ʒu(transform.position)�̍X�V
            // �ړ������x�N�g��(velocity)�𑫂����݂܂�
            transform.position += velocity;
        //}
        diff = transform.position - latestPos;   //�O�񂩂�ǂ��ɐi�񂾂����x�N�g���Ŏ擾
        latestPos = transform.position;  //�O���Position�̍X�V

        //�x�N�g���̑傫����0.01�ȏ�̎��Ɍ�����ς��鏈��������
        if (diff.magnitude > 0.01f && start == 0)
        {
            start = 1;
        }
        else if (diff.magnitude > 0.01f && start == 1) {

            transform.rotation = Quaternion.LookRotation(diff); //������ύX����
        }

        

    }
}