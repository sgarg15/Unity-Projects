﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  int coinCount;
  float speed = 6;
  Vector3 velocity;

  Rigidbody myRigidbody;
  // Start is called before the first frame update
  void Start() {
    myRigidbody = GetComponent<Rigidbody> ();
  }

  // Update is called once per frame
  void Update() {
    Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    Vector3 direction = input.normalized;
    velocity = direction * speed;
  }

  void FixedUpdate() {
    myRigidbody.position += velocity * Time.fixedDeltaTime;
  }

  void OnTriggerEnter(Collider triggerCollider){
    if(triggerCollider.tag == "Coin") {
      Destroy(triggerCollider.gameObject);
      coinCount++;
    }
    print(coinCount);
  }
}
