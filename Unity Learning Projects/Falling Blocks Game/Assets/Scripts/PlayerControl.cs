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
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            if(touch.position.x < Screen.width / 2) {
                transform.position += new Vector3((-1 * speed) * Time.deltaTime, 0, 0);
            }

            if(touch.position.x > Screen.width / 2) {
                transform.position += new Vector3((1 * speed) * Time.deltaTime, 0, 0);
            }
        }

        //transform.position += moveAmount;

        if (transform.position.x < -screenHalfWidthInWorldUnits) {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }

        if (transform.position.x > screenHalfWidthInWorldUnits) {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D triggerCollider) {
        if (triggerCollider.tag == "Falling Block") {
            if (OnPlayerDeath != null) {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
