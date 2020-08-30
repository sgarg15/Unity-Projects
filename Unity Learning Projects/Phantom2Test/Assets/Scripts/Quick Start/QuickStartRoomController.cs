using Photon.Pun;
using UnityEngine;

public class QuickStartRoomController : MonoBehaviourPunCallbacks {

  [SerializeField]
  private int multiplayerSceneIndex; //Number for the build Index to the multiplay scene

  public override void OnEnable(){
    PhotonNetwork.AddCallbackTarget(this);
  }

  public override void OnDisable(){
    PhotonNetwork.RemoveCallbackTarget(this);
  }

  public override void OnJoinedRoom(){
    Debug.Log("Joined Room");
    StartGame();
  }

  private void StartGame(){
    if(PhotonNetwork.IsMasterClient){
      Debug.Log("Starting Game");
      PhotonNetwork.LoadLevel(multiplayerSceneIndex);
    }
  }
}
