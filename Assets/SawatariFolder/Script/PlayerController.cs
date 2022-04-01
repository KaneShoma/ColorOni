using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;              // 移動方向
    [SerializeField] private float moveSpeed = 5.0f;        // 移動速度
    [SerializeField] private float applySpeed = 0.2f;       // 振り向きの適用速度
    private Vector3 latestPos = new Vector3(0, 0, 0);
    private Vector3 diff= new Vector3(0, 0, 0);
    private int start=0;
   

    void Update()
    {
       
        // WASD入力から、XZ平面(水平な地面)を移動する方向(velocity)を得ます
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            velocity.z += 1;
        
        if (Input.GetKey(KeyCode.A))
            velocity.x -= 1;
        
        if (Input.GetKey(KeyCode.S))
            velocity.z -= 1;
        
        if (Input.GetKey(KeyCode.D))
            velocity.x += 1;
        

        // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        // いずれかの方向に移動している場合
        /*if (velocity.magnitude > 0)
        {
            // プレイヤーの回転(transform.rotation)の更新
            // 無回転状態のプレイヤーのZ+方向(後頭部)を、移動の反対方向(-velocity)に回す回転とします
            transform.rotation = Quaternion.LookRotation(-velocity);
        */
            // プレイヤーの位置(transform.position)の更新
            // 移動方向ベクトル(velocity)を足し込みます
            transform.position += velocity;
        //}
        diff = transform.position - latestPos;   //前回からどこに進んだかをベクトルで取得
        latestPos = transform.position;  //前回のPositionの更新

        //ベクトルの大きさが0.01以上の時に向きを変える処理をする
        if (diff.magnitude > 0.01f && start == 0)
        {
            start = 1;
        }
        else if (diff.magnitude > 0.01f && start == 1) {

            transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
        }

        

    }
}