using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks {

  // Start is called before the first frame update
  void Start() {
    PhotonNetwork.ConnectUsingSettings(); // Connects to photon master servers
  }

  public override void OnConnectedToMaster(){
    Debug.Log("We are now connected to the " + PhotonNetwork.CloudRegion + "Server !");
  }

  // Update is called once per frame
  void Update() {

  }
}
