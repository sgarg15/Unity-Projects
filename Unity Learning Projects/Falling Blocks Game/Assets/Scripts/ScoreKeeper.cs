using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
  public Text realTime;
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    realTime.text = Time.timeSinceLevelLoad.ToString("F1");
  }
}
