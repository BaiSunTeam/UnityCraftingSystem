using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
    private PlayerInputs playerInputs;
    private InputAction movementInput;
    private InputAction toggleInventoryInput;
    private Vector2 moveDirection = Vector2.zero;

    private Rigidbody2D rb;
    public float moveSpeed = 5f;

    Inventory inventory;
    [SerializeField] private UI_PlayerMenu uiPlayerMenu;
    [SerializeField] private UI_Inventory uiInventory;

    public void Awake() {
        playerInputs = new PlayerInputs();

        rb = GetComponent<Rigidbody2D>();
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    void Start() {

    }

    void Update() {
        moveDirection = movementInput.ReadValue<Vector2>();
    }

    void FixedUpdate() {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rb.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null) {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    public Inventory GetInventory() {
        return inventory;
    }

    private void OnEnable() {
        movementInput = playerInputs.Player.Move;
        movementInput.Enable();

        toggleInventoryInput = playerInputs.Player.ToggleInventory;
        toggleInventoryInput.Enable();
        toggleInventoryInput.performed += OnTogglePlayerMenu;
    }

    private void OnDisable() {
        movementInput.Disable();
        toggleInventoryInput.Disable();
        toggleInventoryInput.performed -= OnTogglePlayerMenu;
    }

    private void OnTogglePlayerMenu(InputAction.CallbackContext context) {
        Debug.Log("Current Inv: " + string.Join(", ", inventory.GetItemList()));
        uiPlayerMenu.ToggleView();
        uiInventory.RefreshInventory();
    }


}
