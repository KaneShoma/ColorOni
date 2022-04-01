using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject SousaPanel;
    [SerializeField] GameObject GamePanel;

    void Start()
    {
      //  BackToSousa();
    }

    //��������Ń{�^���������ꂽ�Ƃ�
    public void SelectSousaButton()
    {
        SousaPanel.SetActive(false);
        GamePanel.SetActive(true);
    }

    //�Q�[�������Ń{�^���������ꂽ�Ƃ�
    public void SelectGameButton()
    {
        SousaPanel.SetActive(true);
        GamePanel.SetActive(false);
    }


}
