using UnityEngine;
using UnityEngine.InputSystem;

public class CraftingSystem_Testing : MonoBehaviour {
    [SerializeField] private PlayerController player;
    [SerializeField] private UI_Inventory uiInventory;

    [SerializeField] private ItemSO testItemSO1;
    [SerializeField] private ItemSO testItemSO2;
    [SerializeField] private ItemSO testItemSO3;

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
        Vector3 spawnPosition = new Vector3(Random.Range(-1f, 7f), -3f, 0f);
        Item[] testList = new Item[] { new Item(testItemSO1, 1), new Item(testItemSO2, 1), new Item(testItemSO3, 1) };
        int randomSelect = Random.Range(0, testList.Length);
        ItemWorldSpawner.Instance.SpawnItemWorld(spawnPosition, testList[randomSelect]);
    }

}
