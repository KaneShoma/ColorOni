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
    private float searchTime = 0;   //�o�ߎ���

 
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
        //�v���C���[�Ƌt����������
        var diff = (transform.position - player.transform.position).normalized;
        diff.y = 0;
        transform.rotation = Quaternion.FromToRotation(diff, Vector3.up);
        //�����Ă�������ɐi��
        Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
        gameObject.transform.position += velocity * Time.deltaTime;

        searchTime += Time.deltaTime;

        if(searchTime >= 1.0f)
        {
            nearObj = searchTag(gameObject, "Obstacle");
            //�o�ߎ��Ԃ�������
            searchTime = 0;
        }

        //�Ώۂ̈ʒu�̕���������
        transform.LookAt(nearObj.transform);
        //�v���C���[���甽�΂̌����Ɉړ�����
        transform.Translate(Vector3.forward * 0.01f);

        //agent.SetDestination(GetNextPosition());

        /*//�ړI�n�ɋ߂Â����玟�̖ړI�n������
        agent.ObserveEveryValueChanged(d => agent.remainingDistance)
            .Where(d => d < 2.0f)
            .Where(_ => currentState == EnemyState.TENSION)
            .Subscribe(_ =>
            {
                var nextposition = GetNextPosition();
                agent.SetDestination(nextposition);
            }).AddTo(gameObject);

        //��苗������Ĉ�莞�Ԍo�������Ԃ�߂�
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
        float tmpDis = 0;   //�����p�ꎞ�ϐ�
        float nearDis = 0;  //�ł��߂��I�u�W�F�N�g�̋���
        GameObject targetObj = null;

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
        return targetObj;
    }

   /*public Vector3 GetNextPosition()
    {
        if (m_foundList.Count > 0) m_foundList.Clear();
        m_foundList.AddRange(Physics.OverlapSphere(transform.position, _searchRadius, mask));
        if (m_foundList.Count == 0)
        {
            //�߂��ɂȂ������Ƃ��͔��a40m�̒��ɂ���I�u�W�F�N�g���l�����A�������烉���_���ɑI��
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

        //���ʒu�ɂ���Ƃ��͔͈͓��ɂ���Ƃ݂Ȃ�
        if (toTargetFlatDir.sqrMagnitude <= Mathf.Epsilon) return true;
        return (Vector3.Dot(transform.forward, toTargetFlatDir)) >= m_searchCosTheta;
    }*/
}
