using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{
    //シーンの変更の為のスクリプトです。ゲームオーバー、ゲームクリアを呼び出します。
    //お手数ですが、使用される際はSceneManagerのシーン名修正をお願いします
    // Start is called before the first frame update
    [SerializeField]
    public GameObject BackTitleButton;
    [SerializeField]
    public GameObject Result;
    [SerializeField]
    public static int GameState=1;
    Transform BackTitleButtonTrans;
    Vector3 BackTitleButtonPos;
    private SceneChangerScript scenechangerscript;

    [SerializeField]
    private AudioSource clear_sound;

    public bool check_clear = false;
    void Start()
    {
        BackTitleButtonTrans = BackTitleButton.transform;
        BackTitleButtonPos = BackTitleButtonTrans.localPosition;
        scenechangerscript = GameObject.FindWithTag("SceneManager").GetComponent<SceneChangerScript>();
        

    }

    // Update is called once per frame
     void Update() {
       // Debug.Log("現在のシーン状態:" + GameState);
    }
    public void GameStart()
    {
        SceneManager.LoadScene(SceneManagerScript.Stage1);//ステージ1のシーン名を入力してください。
    }
        public void StageClear()
    {
        if (SceneManager.GetActiveScene().name == SceneManagerScript.Stage1)
        {
            if (check_clear == false)
            {
                check_clear = true;
                Debug.Log("クリアしたので音ならします");
                clear_sound.PlayOneShot(clear_sound.clip);
            }
           
            Result.SetActive(true);
            /*BackTitleButtonPos.x = 20;
            BackTitleButtonPos.y = -416;*/
            BackTitleButtonPos.x = 11;
            BackTitleButtonPos.y = -362;
            BackTitleButtonPos.z = 0;
           BackTitleButtonTrans.localPosition = BackTitleButtonPos;
            /* var gameObject = GameObject.Find("NextStageUI");
             gameObject.SetActive(true);
             if (gameObject == null)
             {
                 return;
             }*/
        }
        else if(SceneManager.GetActiveScene().name == SceneManagerScript.Stage2)
        { 
           //ゲームクリア
            Result.SetActive(true);
            BackTitleButtonPos.x = 11;
            BackTitleButtonPos.y = -362;
            BackTitleButtonPos.z = 0;
            BackTitleButtonTrans.localPosition = BackTitleButtonPos;
            /* var gameObject = GameObject.Find("NextStageUI");
             gameObject.SetActive(true);
             if (gameObject == null)
             {
                 return;
             }*/
        }
        { 

        }
    }
    public void GameOver()
    {
        if (SceneManager.GetActiveScene().name == SceneManagerScript.Stage1)
        {
            GameState = 1;
            
        }
       /* else if (SceneManager.GetActiveScene().name == SceneManagerScript.Stage2)
        {
            GameState = 2;
           
        }*/
       //ゲームオーバー
        SceneManager.LoadScene(SceneManagerScript.GameOver);//ゲームオーバーシーンの名前を入力してください。
    }
    }
