using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
  public float speed = 7;
  public event System.Action OnPlayerDeath;

  float screenHalfWidthInWorldUnits;

  // Start is called before the first frame update
  void Start() {
    float halfPlayerWidth = transform.localScale.x / 2f;
    screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
  }

  // Update is called once per frame
  void Update() {
    Vector3 playerControl = new Vector3(Input.GetAxisRaw("Horizontal"), 0/*Input.GetAxisRaw("Vertical")*/, 0);
    Vector3 direction = playerControl.normalized;
    Vector3 velocity = direction * speed;
    Vector3 moveAmount = velocity * Time.deltaTime;

    transform.position += moveAmount;

    if(transform.position.x < -screenHalfWidthInWorldUnits) {
      transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
    }

    if(transform.position.x > screenHalfWidthInWorldUnits) {
      transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
    }
  }

  void OnTriggerEnter2D(Collider2D triggerCollider){
    if(triggerCollider.tag == "Falling Block"){
      if (OnPlayerDeath != null) {
        OnPlayerDeath ();
      }
      Destroy(gameObject);
    }
  }
}
