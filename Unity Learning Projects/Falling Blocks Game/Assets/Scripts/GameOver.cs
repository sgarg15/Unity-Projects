using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public GameObject gameOverScreen;
    public GameObject timeKeeper;
    float highscore = 0;
    public Text secondsSurvivedUI;
    public Text highscoreUI;
    bool gameOver;

    void Start() {
        FindObjectOfType<PlayerControl>().OnPlayerDeath += OnGameOver;

        highscore = PlayerPrefs.GetFloat("highscore");
        highscoreUI.text = highscore.ToString();
    }
    // Update is called once per frame
    void Update() {
        if (gameOver) {
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began) {
                    SceneManager.LoadScene("Game");
                }
            }
        }
    }

    void OnGameOver() {
        gameOverScreen.SetActive(true);
        timeKeeper.SetActive(false);
        secondsSurvivedUI.text = Time.timeSinceLevelLoad.ToString("F1");
        if (Time.timeSinceLevelLoad > highscore) {
            highscore = Time.timeSinceLevelLoad;
            PlayerPrefs.SetFloat("highscore", highscore);
        }
        highscoreUI.text = highscore.ToString("F1");
        gameOver = true;
    }
}
