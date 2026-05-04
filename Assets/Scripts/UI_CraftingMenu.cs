using UnityEngine;

public class UI_CraftingMenu : MonoBehaviour {
    private readonly float _outputSlotCellSize = 40f;
    private readonly float _inputSlotCellSize = 30f;

    private Inventory inventory;

    public void RefreshCraftingMenu() {
        Debug.Log("Refreshed crafting menu");
    }
    
    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
        inventory.OnItemListChanged += OnItemListChangedEvent;
        RefreshCraftingMenu();
    }

    private void OnItemListChangedEvent(object sender, System.EventArgs e) {
        RefreshCraftingMenu();
    }
}