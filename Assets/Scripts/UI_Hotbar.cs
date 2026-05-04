using UnityEngine;

public class UI_Hotbar : MonoBehaviour {
    private readonly float _outputSlotCellSize = 40f;
    private readonly float _inputSlotCellSize = 30f;

    private Inventory inventory;

    public void RefreshHotbar() {
        Debug.Log("Refreshed hotbar");
    }
    
    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
        inventory.OnItemListChanged += OnItemListChangedEvent;
        RefreshHotbar();
    }

    private void OnItemListChangedEvent(object sender, System.EventArgs e) {
        RefreshHotbar();
    }
}