using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines : MonoBehaviour {

  public Transform[] path;
  IEnumerator currentMoveCoroutine;

  // Start is called before the first frame update
  void Start() {
    string [] message = {"Welcome", "to", "Iceland"};
    StartCoroutine (PrintMessages (message, 0.5f));
    StartCoroutine (FollowPath ());
  }

  // Update is called once per frame
  void Update() {
    if(Input.GetKeyDown(KeyCode.Space)){
      if (currentMoveCoroutine != null){
        //to stop coroutine, you need reference to current running coroutine
        StopCoroutine (currentMoveCoroutine);
      }
      currentMoveCoroutine = Move(Random.onUnitSphere * 5, 8);
      StartCoroutine(currentMoveCoroutine);
    }
  }

  IEnumerator FollowPath() {
    foreach (Transform waypoint in path) {
      //pause coroutine until the coroutine has finished
      yield return StartCoroutine (Move(waypoint.position, 8));
    }
  }

  IEnumerator Move(Vector3 destination, float speed) {
    while(transform.position != destination) {
      transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
      //pause coroutine until next frame
      yield return null;
    }
  }

  IEnumerator PrintMessages (string[] message, float delay) {
    foreach (string msg in message) {
      print (msg);
      //pause Coroutine for delay amount
      yield return new WaitForSeconds (delay);
    }
  }
}
