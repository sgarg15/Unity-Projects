using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
  public GameObject gameOverScreen;
  public GameObject timeKeeper;
  public Text secondsSurvivedUI;
  bool gameOver;

  void Start() {
    FindObjectOfType<PlayerControl> ().OnPlayerDeath += OnGameOver;
  }
  // Update is called once per frame
  void Update() {
    if(gameOver){
      if (Input.GetKeyDown(KeyCode.Space)){
        SceneManager.LoadScene(0);
      }
    }
  }

  void OnGameOver(){
      gameOverScreen.SetActive (true);
      timeKeeper.SetActive (false);
      secondsSurvivedUI.text = Time.timeSinceLevelLoad.ToString("F1");
      gameOver = true;
  }
}
