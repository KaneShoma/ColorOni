using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    float speed = 3;
    private GameObject nearObj;
    private float searchTime = 0;   //経過時間

 
    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        nearObj = searchTag(gameObject, "Obstacle");
    }

    private void Update()
    {

    }

    public void OnDetectObject(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Run();
        }
    }

    public void Run()
    {
        //プレイヤーと逆方向を向く
        var diff = (transform.position - player.transform.position).normalized;
        diff.y = 0;
        transform.rotation = Quaternion.FromToRotation(diff, Vector3.up);
        //向いている方向に進む
        Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
        gameObject.transform.position += velocity * Time.deltaTime;

        searchTime += Time.deltaTime;

        if(searchTime >= 1.0f)
        {
            nearObj = searchTag(gameObject, "Obstacle");
            //経過時間を初期化
            searchTime = 0;
        }

        //対象の位置の方向を向く
        transform.LookAt(nearObj.transform);
        //プレイヤーから反対の向きに移動する
        transform.Translate(Vector3.forward * 0.01f);

        //agent.SetDestination(GetNextPosition());

        /*//目的地に近づいたら次の目的地を検索
        agent.ObserveEveryValueChanged(d => agent.remainingDistance)
            .Where(d => d < 2.0f)
            .Where(_ => currentState == EnemyState.TENSION)
            .Subscribe(_ =>
            {
                var nextposition = GetNextPosition();
                agent.SetDestination(nextposition);
            }).AddTo(gameObject);

        //一定距離離れて一定時間経ったら状態を戻す
        this.UpdateAsObservable()
            .TakeWhile(_ => currentState == EnemyState.TENSION)
            .Select(_ => (transform.position - player.transform.position).sqrMagnitude)
            .Where(distance => distance > targetDistance * targetDistance)
            .Subscribe(distance =>
            {
                escapeTime += Time.deltaTime;
                if (escapeTime >= 10) Usual();
            });*/
    }

    GameObject searchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;   //距離用一時変数
        float nearDis = 0;  //最も近いオブジェクトの距離
        GameObject targetObj = null;

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
        return targetObj;
    }

   /*public Vector3 GetNextPosition()
    {
        if (m_foundList.Count > 0) m_foundList.Clear();
        m_foundList.AddRange(Physics.OverlapSphere(transform.position, _searchRadius, mask));
        if (m_foundList.Count == 0)
        {
            //近くになかったときは半径40mの中にあるオブジェクトを獲得し、そこからランダムに選ぶ
            m_foundList.AddRange(Physics.OverlapSphere(transform.position, 40.0f, mask));
            foreach (var obj in m_foundList) Debug.Log(obj.gameObject.name);
        }
        else
        {
            for (int i = 0; i < m_foundList.Count; i++)
            {
                var foundData = m_foundList[i];
                if (!CheckFoundObject(foundData.gameObject))
                    m_foundList.Remove(foundData);
            }
        }

        return m_foundList.Count > 0 ? m_foundList[Random.Range(0, m_foundList.Count - 1)].transform.position : Vector3.zero;
    }
    /*
    private bool CheckFoundObject(GameObject i_target)
    {
        var myPositionXZ = Vector3.Scale(transform.position, new Vector3(1.0f, 0.0f, 1.0f));
        var targetPositionXZ = Vector3.Scale(i_target.transform.position, new Vector3(1.0f, 0.0f, 1.0f));
        var toTargetFlatDir = (targetPositionXZ - myPositionXZ).normalized;

        //同位置にいるときは範囲内にいるとみなす
        if (toTargetFlatDir.sqrMagnitude <= Mathf.Epsilon) return true;
        return (Vector3.Dot(transform.forward, toTargetFlatDir)) >= m_searchCosTheta;
    }*/
}
