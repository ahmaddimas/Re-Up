using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;         
    public Text scoreText;
	public Text SkorText;
	public Text HighText;
	public GameObject GameOverCanvas;
	public GameObject PauseCanvas;
    public GameObject gameOvertext;

    private int score = 0;
	private int highscore;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
		
    }

	void Start() {
		GameObject go = GameObject.Find ("SoundManager");
		backgroundMusic other = (backgroundMusic)go.GetComponent (typeof(backgroundMusic));
		highscore = other.highscore;
	}

    void Update()
    {
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				if (!PauseCanvas.activeInHierarchy && !GameOverCanvas.activeInHierarchy) {
					PauseCanvas.SetActive (true);
					Time.timeScale = 0;
					return;
				}
				if (GameOverCanvas.activeInHierarchy) {
					SceneManager.LoadScene("MainMenu");
					Time.timeScale = 1;
					return;
				}
			}
		}
    }

	public void Restart () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		PauseCanvas.SetActive (false);
		Time.timeScale = 1;
	}

	public void Resume () {
		PauseCanvas.SetActive (false);
		Time.timeScale = 1;
	}

    public void BirdScored()
    {
        if (gameOver)
            return;
        score++;
        scoreText.text = "SCORE : " + score.ToString();
    }

    public void BirdDied()
    {
		if (score > highscore) {
			GameObject go = GameObject.Find ("SoundManager");
			backgroundMusic other = (backgroundMusic)go.GetComponent (typeof(backgroundMusic));
			highscore = score;
			other.setScore (score);
		}
		HighText.text = "High Score : " + highscore.ToString ();
		SkorText.text = "Score : " + score.ToString ();
		GameOverCanvas.SetActive (true);

        gameOver = true;
    }
}