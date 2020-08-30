using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayStartRoomController : MonoBehaviourPunCallbacks {

  [SerializeField]
  private int waitingRoomSceneIndex; //Number for the build Index to the multiplay scene

  public override void OnEnable(){
    //register to photon callback functions
    PhotonNetwork.AddCallbackTarget(this);
  }

  public override void OnDisable(){
    //unregister to photon callback functions
    PhotonNetwork.RemoveCallbackTarget(this);
  }

  public override void OnJoinedRoom(){
    Debug.Log("Joined Room");
    SceneManager.LoadScene(waitingRoomSceneIndex);
  }
}
