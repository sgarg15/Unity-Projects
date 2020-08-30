using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour {

  public float speed = 10.0f;
  //Vector3 velocity;

  //Rigidbody myRigidbody;

  // Start is called before the first frame update
  void Start() {
  //  myRigidbody = GetComponent<Rigidbody> ();
    Cursor.lockState = CursorLockMode.Locked;
  }

  // Update is called once per frame
  void Update() {
    float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
    float straffe = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
    transform.Translate(straffe, 0, translation);
    /*Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    Vector3 direction = input.normalized;
    velocity = direction * speed;*/

    if(Input.GetKeyDown("escape")){
      Cursor.lockState = CursorLockMode.None;
    }
  }

/*  void FixedUpdate() {
    myRigidbody.position += velocity * Time.fixedDeltaTime;
  }
*/
}
