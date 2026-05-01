using UnityEngine;
using UnityEngine.InputSystem;

public class CraftingSystem_Testing : MonoBehaviour {
    [SerializeField] private PlayerController player;
    [SerializeField] private UI_Inventory uiInventory;

    [SerializeField] private ItemSO testItemSO;

    private PlayerInputs playerInputs;
    private InputAction toggleTest;

    public void Awake() {
        playerInputs = new PlayerInputs();
    }

    private void OnEnable() {
        toggleTest = playerInputs.Player.ToggleTest;
        toggleTest.Enable();
        toggleTest.performed += OnToggleTest;
    }

    private void OnDisable() {
        toggleTest.Disable();
        toggleTest.performed -= OnToggleTest;
    }

    private void OnToggleTest(InputAction.CallbackContext context) {
        Vector3 spawnPosition = new Vector3(Random.Range(-1f, 7f), -3f);

        Item testItem = new Item(testItemSO, 1);
        ItemWorldSpawner.Instance.SpawnItemWorld(spawnPosition, testItem);
    }

}
