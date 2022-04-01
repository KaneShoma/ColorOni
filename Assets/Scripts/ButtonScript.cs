using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{//�{�^���ɂ��X�e�[�W�J�ڂ���������X�N���v�g�ł��B�{�^���n�͑������̃X�N���v�g�P�̂ŉ��Ƃ��Ȃ�(�͂�!!)���ɂ��Ă�̂̓Q�[���I���p�̊֐��ł��B
    //���萔�ł����A�g�p�����ۂ�SceneManager�̃V�[�����C�������肢���܂�
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
            //���O���uGameStartButton�v�̂Ƃ�
            case "GameStartButton":
                //�A�j���[�V������
                Debug.Log("�A�j���[�V�������s");
                anim.PlayOneShot(anim.clip);
                //Stage1Scene�Ɉړ�
                changeanim.Changeanim();
                                                                  //�A�j���[�V�����Đ��X�N���v�g
          

                //break��
                break;
            //���O���uCube�v�̂Ƃ�
            case "EndGameButton":
                //�{�^����
                Quit();
                
                break;
            
            case "BackTitleButton":
                //�{�^����
                SceneManager.LoadScene(SceneManagerScript.Title);
                break;
            case "NextStageButton":
                //�{�^����
                SceneManager.LoadScene(SceneManagerScript.Stage2);
                break;
            case "CreditButton":
                //�{�^����
                    SceneManager.LoadScene(SceneManagerScript.Credit);
                break;
            case "TutrialButton":
                //�{�^����
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
                  //�{�^����
                    SceneManager.LoadScene(SceneManagerScript.Stage2);
                   // Debug.Log("�J�ڌ�̃V�[�����:" + SceneChangerScript.GameState);
                    //break��
                    break;
                   
                }


               
                
        }
    }

    public void On_Click()
    {
        Debug.Log("�{�^��������܂�");
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
