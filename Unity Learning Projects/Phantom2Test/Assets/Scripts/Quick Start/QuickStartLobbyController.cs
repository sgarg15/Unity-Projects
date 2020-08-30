using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks {

  [SerializeField]
  private GameObject quickStartButton; //button used for creating and joining a game
  [SerializeField]
  private GameObject quickCancelButton; // button used to stop searing for a game to Join
  [SerializeField]
  private int RoomSize; // Manual set the number of player in the room at one time

  public override void OnConnectedToMaster(){
    PhotonNetwork.AutomaticallySyncScene = true; // makes it so whatever scene the master client has
    quickStartButton.SetActive(true);
  }

  public void QuickStart(){
    quickStartButton.SetActive(false);
    quickCancelButton.SetActive(true);
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
    RoomOptions roomOps = new RoomOptions() {IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize};
    PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
    Debug.Log(randomRoomNumber);
  }

  public override void OnCreateRoomFailed(short returnCode, string message){
    Debug.Log("Failed to create room... trying again");
    CreateRoom();
  }

  public void QuickCancel(){
    quickStartButton.SetActive(true);
    quickCancelButton.SetActive(false);
    PhotonNetwork.LeaveRoom();
  }
}
