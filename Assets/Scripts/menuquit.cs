using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuquit : MonoBehaviour {
	public Canvas canvas;
	public Canvas setting;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				showPopup ();

				return;
			}
	 	}
	}

	public void Exit () {
		Application.Quit ();
	}

	public void showPopup(){
		canvas.enabled = true;
	}

	public void ExitPopup () {
		canvas.enabled = false;
	}

	public void showSetting (){
		setting.enabled = true;
	}

	public void ExitSetting () {
		setting.enabled = false;
	}
}
