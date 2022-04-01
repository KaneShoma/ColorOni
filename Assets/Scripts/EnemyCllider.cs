using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]

public class EnemyCllider : MonoBehaviour
{
    [SerializeField] private UnityEvent onTriggerStay = new UnityEvent();

    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke();
    }

    [SerializeField]
    public class TriggerEvent : UnityEvent<Collider> { }
}
