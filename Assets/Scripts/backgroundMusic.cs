using UnityEngine;
using System.Collections;

public class backgroundMusic : MonoBehaviour {

	private static backgroundMusic instance = null;
	public static backgroundMusic Instance {
		get { return instance; }
	}

	private AudioSource source { get { return GetComponent<AudioSource>(); } }
	public AudioClip sound;

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
		StartAudio ();
	}

	public void StartAudio () {
		source.Play ();
	}

	public void PauseAudio () {
		source.Stop ();
	}

}
