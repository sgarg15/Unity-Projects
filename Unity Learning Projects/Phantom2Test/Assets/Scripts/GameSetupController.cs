using Photon.Pun;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviour {

  // Start is called before the first frame update
  void Start() {
    CreatePlayer();
  }

  private void CreatePlayer(){
    Debug.Log("Create Player");
    PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), Vector3.zero, Quaternion.identity);
  }

  // Update is called once per frame
  void Update() {

  }
}
