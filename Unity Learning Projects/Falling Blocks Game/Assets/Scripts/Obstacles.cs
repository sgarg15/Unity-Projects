using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {
  public Vector2 speedMinMax;
  float speed;
  float visibleLightThreshold;
  void Start () {
    speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
    visibleLightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
  }
  // Update is called once per frame
  void Update() {
    transform.Translate(Vector3.down * speed * Time.deltaTime);

    if(transform.position.y < visibleLightThreshold){
      Destroy(gameObject);
    }
  }
}
