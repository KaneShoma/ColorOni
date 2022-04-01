using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{
    //�V�[���̕ύX�ׂ̈̃X�N���v�g�ł��B�Q�[���I�[�o�[�A�Q�[���N���A���Ăяo���܂��B
    //���萔�ł����A�g�p�����ۂ�SceneManager�̃V�[�����C�������肢���܂�
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
       // Debug.Log("���݂̃V�[�����:" + GameState);
    }
    public void GameStart()
    {
        SceneManager.LoadScene(SceneManagerScript.Stage1);//�X�e�[�W1�̃V�[��������͂��Ă��������B
    }
        public void StageClear()
    {
        if (SceneManager.GetActiveScene().name == SceneManagerScript.Stage1)
        {
            if (check_clear == false)
            {
                check_clear = true;
                Debug.Log("�N���A�����̂ŉ��Ȃ炵�܂�");
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
           //�Q�[���N���A
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
       //�Q�[���I�[�o�[
        SceneManager.LoadScene(SceneManagerScript.GameOver);//�Q�[���I�[�o�[�V�[���̖��O����͂��Ă��������B
    }
    }
