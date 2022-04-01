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

    //操作説明でボタンが押されたとき
    public void SelectSousaButton()
    {
        SousaPanel.SetActive(false);
        GamePanel.SetActive(true);
    }

    //ゲーム説明でボタンが押されたとき
    public void SelectGameButton()
    {
        SousaPanel.SetActive(true);
        GamePanel.SetActive(false);
    }


}
