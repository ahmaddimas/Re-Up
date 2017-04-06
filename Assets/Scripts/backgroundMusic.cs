using UnityEngine;
using System.Collections;

public class backgroundMusic : MonoBehaviour {

	private static backgroundMusic instance;
	public static backgroundMusic Instance {
		get { return instance; }
	}

	private AudioSource source { get { return GetComponent<AudioSource>(); } }
	public AudioClip sound;

	public bool active = true;
	public bool tone = true;

	public int highscore = 0;

	void Awake()
	{
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}

	void Start() {
		source.clip = sound;
		source.Play ();
	}

	public void StartAudio () {
		source.UnPause ();
	}

	public void PauseAudio () {
		source.Pause ();
	}

	public bool getActive () {
		return active;
	}

	public void setActive (bool e) {
		active = e;
	}

	public bool getTone () {
		return tone;
	}

	public void setTone (bool e) {
		tone = e;
	}

	public void setScore (int e) {
		highscore = e;
	}
}
