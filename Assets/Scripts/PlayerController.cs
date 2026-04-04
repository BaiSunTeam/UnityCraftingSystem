using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private PlayerInputs playerInputs;
    private InputAction movementInput;
    private InputAction toggleInventoryInput;
    private Vector2 moveDirection = Vector2.zero;

    private Rigidbody2D rb;
    public float moveSpeed = 5f;

    Inventory inventory;

    public void Awake()
    {
        playerInputs = new PlayerInputs();

        rb = GetComponent<Rigidbody2D>();
        inventory = new Inventory();
    } 

    void Start()
    {

    }

    void Update()
    {
        moveDirection = movementInput.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y);
    }

    public Inventory GetInventory() { 
        return inventory; 
    }

    private void OnEnable()
    {
        movementInput = playerInputs.Player.Move;
        movementInput.Enable();
    }

    private void OnDisable()
    {
        movementInput.Enable();
    }
}
