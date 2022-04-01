using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public static string Stage1="GameStage";
    [SerializeField]
    public static string Stage2 = "Stage2Scene";
    [SerializeField]
    public static string GameOver = "GameOverScene";
    [SerializeField]
    public static string Title = "TitleScene";
    [SerializeField]
    public static string Credit = "CreditScene";
    [SerializeField]
    public static string Tutrial = "NewTutorial";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
