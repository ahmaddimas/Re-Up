using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;         
    public Text scoreText;                      
    public GameObject gameOvertext;            

    private int score = 0;                     
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
		GameObject go = GameObject.Find("SoundManager");
		backgroundMusic other = (backgroundMusic) go.GetComponent(typeof(backgroundMusic));
		other.PauseAudio();
	}

    void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				SceneManager.LoadScene("MainMenu");

				GameObject go = GameObject.Find("SoundManager");
				backgroundMusic other = (backgroundMusic) go.GetComponent(typeof(backgroundMusic));
				other.StartAudio ();

				return;
			}
		}
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
        gameOvertext.SetActive(true);
        gameOver = true;
    }
}