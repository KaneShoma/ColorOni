using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnImage : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;

    public ChahgeColor ChahgeColor;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ChahgeColor.DelCheck == true)
        {
            Debug.Log("�������̂ŃL�����o�X�t���܂�");
            canvas.SetActive(true);
        }  
    }
}
