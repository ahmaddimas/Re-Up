using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class cliclFunction : MonoBehaviour {
    public AudioClip sound;

    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    // Use this for initialization
    void Awake () {
        // gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;

//		button.onClick.AddListener(() => PlaySound());
	}
	
	// Update is called once per frame
	void PlaySound () {
		source.PlayOneShot (sound);
	}
}
