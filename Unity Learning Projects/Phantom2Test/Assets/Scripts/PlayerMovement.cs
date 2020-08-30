using Photon.Pun;
using UnityEngine;


public class PlayerMovement : MonoBehaviour, IPunObservable {

  PhotonView photonView;

  void Awake() {
    photonView = GetComponent<PhotonView>();

    photonView.ObservedComponents.Add(this);
    if (!photonView.IsMine) {
        enabled = false;
    }
  }
    // Update is called once per frame
  void Update() {
    if (photonView.IsMine) {
      if (Input.GetKey(KeyCode.W)) {
          transform.position += Vector3.forward *Time.deltaTime * 10;
      }
      if (Input.GetKey(KeyCode.A)) {
          transform.position += Vector3.left *Time.deltaTime * 10;
      }
      if (Input.GetKey(KeyCode.S)) {
          transform.position += Vector3.back *Time.deltaTime * 10;
      }
      if (Input.GetKey(KeyCode.D)) {
          transform.position += Vector3.right *Time.deltaTime * 10;
      }
    }
  }

  void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
    if (stream.IsWriting) {
      // We own this player: send the others our data
      stream.SendNext(transform.position); //position of the character
      stream.SendNext(transform.rotation); //rotation of the character
    } else {
      // Network player, receive data
      Vector3 syncPosition = (Vector3)stream.ReceiveNext();
      Quaternion syncRotation = (Quaternion)stream.ReceiveNext();
    }
  }
}
