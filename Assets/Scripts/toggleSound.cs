using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class toggleSound : MonoBehaviour {
	public Sprite bg1;
	public Sprite bg2;
	public Toggle toggle;
	public bool active;

	void Awake() {
		GameObject go = GameObject.Find ("SoundManager");
		backgroundMusic other = (backgroundMusic)go.GetComponent (typeof(backgroundMusic));
		active = other.getActive();
	}
	// Use this for initialization
	void Start () {
		if (active == true) {
			toggle.isOn = true;
		} else if (active == false) {
			toggle.isOn = false;
		}
		Sound ();
	}
	
	void Update () {
		Sound ();
	}

	void Sound () {
		GameObject go = GameObject.Find ("SoundManager");
		backgroundMusic other = (backgroundMusic)go.GetComponent (typeof(backgroundMusic));

		Image image = toggle.targetGraphic as Image;

		if (toggle.isOn) {
			other.setActive (true);
			image.overrideSprite = bg1;
			other.StartAudio ();
		} else {
			other.setActive (false);
			image.overrideSprite = bg2;
			other.PauseAudio ();
		}
	}
}
