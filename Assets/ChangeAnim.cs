using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class ChangeAnim : MonoBehaviour
{

    [SerializeField] private PlayableDirector _director;
    private PlayableDirector director;
    private PlayBGM playbgm;
    public AudioSource SwitchBGM;

    public void Start()
    {
        playbgm = GameObject.FindWithTag("SceneManager").GetComponent<PlayBGM>();
    }
    public void Changeanim()
    {
        playbgm.TitleBGM.Stop();
        _director.Play();
    }
    public void Retryanim()
    {
        playbgm.TitleBGM.Stop();
        SwitchBGM.Play();
        _director.Play();
    }

}

