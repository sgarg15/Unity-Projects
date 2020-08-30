using Mirror;
using UnityEngine;

public class PlayerMovementController : NetworkBehaviour {

  [SerializeField]
  private float movementSpeed = 5f;
  [SerializeField]
  private CharacterController controller = null;

  [Header("Firing")]
  public KeyCode shootKey = KeyCode.Space;
  public GameObject projectilePrefab;
  public Transform projectileMount;

  private Vector2 previousInput;

  private Controls controls;
  private Controls Controls{
      get{
          if(controls != null){
              return controls;
          }
          return controls = new Controls();
      }
  }

  public override void OnStartAuthority(){
    enabled = true;

    Controls.Player.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
    Controls.Player.Move.canceled += ctx => ResetMovement();
  }

  [ClientCallback]
  private void OnEnable() {
    Controls.Enable();
  }
  [ClientCallback]
  private void OnDisable() {
      Controls.Disable();
  }

  // Update is called once per frame
  [ClientCallback]
  private void Update() {
    Move();

    if (Input.GetKeyDown(shootKey)) {
      CmdFire();
    }
  }

  [Command]
  void CmdFire() {
      GameObject projectile = Instantiate(projectilePrefab, projectileMount.position, transform.rotation);
      projectile.GetComponent<Projectile>().source = gameObject;
      NetworkServer.Spawn(projectile);
  }

  [Client]
  private void SetMovement(Vector2 movement){
    previousInput = movement;
  }

  [Client]
  private void ResetMovement(){
    previousInput = Vector2.zero;
  }

  [Client]
  private void Move(){
    Vector3 right = controller.transform.right;
    Vector3 forward = controller.transform.forward;
    right.y = 0f;
    forward.y = 0f;

    Vector3 movement = right.normalized * previousInput.x + forward.normalized * previousInput.y; 

    controller.Move(movement * movementSpeed * Time.deltaTime);
  }
}