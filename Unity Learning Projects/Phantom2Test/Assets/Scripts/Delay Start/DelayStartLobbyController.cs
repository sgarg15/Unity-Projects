using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class DelayStartLobbyController : MonoBehaviourPunCallbacks {

  [SerializeField]
  private GameObject delayStartButton; //button used for creating and joining a game
  [SerializeField]
  private GameObject delayCancelButton; // button used to stop searing for a game to Join
  [SerializeField]
  private int roomSize; // Manual set the number of player in the room at one time

  public override void OnConnectedToMaster(){
    PhotonNetwork.AutomaticallySyncScene = true; // makes it so whatever scene the master client has
    delayStartButton.SetActive(true);
  }

  public void DelayStart(){
    delayStartButton.SetActive(false);
    delayCancelButton.SetActive(true);
    PhotonNetwork.JoinRandomRoom();
    Debug.Log("QuickStart");
  }

  public override void OnJoinRandomFailed(short returnCode, string message){
    Debug.Log("Failed to join a room");
    CreateRoom();
  }

  void CreateRoom(){
    Debug.Log("Creating Room now");
    int randomRoomNumber = Random.Range(0, 10000);
    RoomOptions roomOps = new RoomOptions() {IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize};
    PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
    Debug.Log(randomRoomNumber);
  }

  public override void OnCreateRoomFailed(short returnCode, string message){
    Debug.Log("Failed to create room... trying again");
    CreateRoom();
  }

  public void DelayCancel(){
    delayStartButton.SetActive(true);
    delayCancelButton.SetActive(false);
    PhotonNetwork.LeaveRoom();
  }
}
