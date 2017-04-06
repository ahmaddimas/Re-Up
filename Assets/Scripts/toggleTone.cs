using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class toggleTone : MonoBehaviour {
	public Sprite bg1;
	public Sprite bg2;
	public Toggle toggle;
	public bool tone;

	void Awake() {
		GameObject go = GameObject.Find ("SoundManager");
		backgroundMusic other = (backgroundMusic)go.GetComponent (typeof(backgroundMusic));
		tone = other.getTone();
	}

	// Use this for initialization
	void Start () {
		if (tone == true) {
			toggle.isOn = true;
		} else if (tone == false) {
			toggle.isOn = false;
		}
		// toggle.toggleTransition = Toggle.ToggleTransition.None;
	}

	void Update () {
		GameObject go = GameObject.Find ("SoundManager");
		backgroundMusic other = (backgroundMusic)go.GetComponent (typeof(backgroundMusic));

		Image image = toggle.targetGraphic as Image;

		if (toggle.isOn) {
			other.setTone (true);
			image.overrideSprite = bg1;
		} else {
			other.setTone (false);
			image.overrideSprite = bg2;
		}
	}
}
