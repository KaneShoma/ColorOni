using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject otherCamera;
	[SerializeField]
	public GameObject UI1;
	[SerializeField]
	public GameObject UI2;
	[SerializeField]
	public static int CameraState = 1;
	[SerializeField]
	private AudioSource ChangeUI;

	void Update()
	{
		//　1キーを押したらカメラの切り替えをする
		if (Input.GetKeyDown("1"))
		{
			ChangeUI.PlayOneShot(ChangeUI.clip);
			mainCamera.SetActive(!mainCamera.activeSelf);
			otherCamera.SetActive(!otherCamera.activeSelf);
			UI1.SetActive(!UI1.activeSelf);
			UI2.SetActive(!UI2.activeSelf);
		}
	}
}
