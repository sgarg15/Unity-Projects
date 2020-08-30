﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour {
  public LayerMask mask;
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    Ray ray = new Ray(transform.position, transform.forward);
    RaycastHit hitInfo;

    if(Physics.Raycast(ray, out hitInfo, 100, mask, QueryTriggerInteraction.Ignore)){
      Destroy(hitInfo.collider.gameObject);
      Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
    } else {
      Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
    }
  }
}
