using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour {
	private AudioSource source { get { return GetComponent<AudioSource>(); } }
	public AudioClip sound;

	// public Texture2D fadeOutTexture;
	// public float fadeSpeed = 0.8f;

	// private int drawDepth = -1000;
	// private float alpha = 1.0f;
	// private int fadeDir = -1;

	// void OnGUI() {
	// 	alpha += fadeDir * fadeSpeed * Time.deltaTime;
	// 	alpha = Mathf.Clamp01 (alpha);

	// 	GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
	// 	GUI.depth = drawDepth;
	// 	GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	// }

	// public float BeginFade (int direction) {
	// 	fadeDir = direction;
	// 	return (fadeSpeed);
	// }

	public void loadScene (string scene)
    {
		startTone ();
		// 	BeginFade (1);
        SceneManager.LoadScene(scene);
    }

	public void startTone(){
		source.PlayOneShot (sound);
	}
}
