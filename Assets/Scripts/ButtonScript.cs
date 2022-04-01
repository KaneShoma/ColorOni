using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{//ボタンによるステージ遷移を実装するスクリプトです。ボタン系は多分このスクリプト単体で何とかなる(はず!!)後ろについてるのはゲーム終了用の関数です。
    //お手数ですが、使用される際はSceneManagerのシーン名修正をお願いします
    string objctName;
    // Start is called before the first frame update

    private SceneChangerScript scenechangerscript;
    private ChangeAnim changeanim;
    private PlayBGM playbgm;

    [SerializeField]
    private AudioSource anim;
    private AudioSource button;

    private void Start()
    {
        //anim = GetComponent<AudioSource>();
        button = GetComponent<AudioSource>();
        playbgm = GameObject.FindWithTag("SceneManager").GetComponent<PlayBGM>();
        scenechangerscript = GameObject.FindWithTag("SceneManager").GetComponent<SceneChangerScript>();
        changeanim = GameObject.FindWithTag("SceneManager").GetComponent<ChangeAnim>();
    }
    public void LoadingNewScene()
    {
        objctName = gameObject.name;
        switch (objctName)
        {
            //名前が「GameStartButton」のとき
            case "GameStartButton":
                //アニメーション音
                Debug.Log("アニメーション実行");
                anim.PlayOneShot(anim.clip);
                //Stage1Sceneに移動
                changeanim.Changeanim();
                                                                  //アニメーション再生スクリプト
          

                //break文
                break;
            //名前が「Cube」のとき
            case "EndGameButton":
                //ボタン音
                Quit();
                
                break;
            
            case "BackTitleButton":
                //ボタン音
                SceneManager.LoadScene(SceneManagerScript.Title);
                break;
            case "NextStageButton":
                //ボタン音
                SceneManager.LoadScene(SceneManagerScript.Stage2);
                break;
            case "CreditButton":
                //ボタン音
                    SceneManager.LoadScene(SceneManagerScript.Credit);
                break;
            case "TutrialButton":
                //ボタン音
                SceneManager.LoadScene(SceneManagerScript.Tutrial);
                break;
            case "RetryUI":
               
                int GameStates = SceneChangerScript.GameState;
              
                if (GameStates == 1)
                {
                    changeanim.Changeanim();
                    break;
                }
                else
                {
                  //ボタン音
                    SceneManager.LoadScene(SceneManagerScript.Stage2);
                   // Debug.Log("遷移後のシーン状態:" + SceneChangerScript.GameState);
                    //break文
                    break;
                   
                }


               
                
        }
    }

    public void On_Click()
    {
        Debug.Log("ボタン音が鳴ります");
        button.PlayOneShot(button.clip);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
