using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    const int ROWS = 6;
    const int COLUMNS = 5;
    const int TOTAL_SLOTS = ROWS * COLUMNS;

    const int OUTER_PADDING = 12;
    const int SLOT_SPACING = 8;

    
    private PlayerController player;
    private Inventory inventory;

    private bool IsOpen { get; set; }

    private void Awake() {
        gameObject.SetActive(true);

        IsOpen = false;
        gameObject.SetActive(IsOpen);
    }

    public void SetPlayer(PlayerController player) { 
        this.player = player;
    }

    public void SetInventory(Inventory inventory) { 
        this.inventory = inventory;
    }

    public void ToggleView()
    {
        IsOpen = !IsOpen;
        gameObject.SetActive(IsOpen);
    }
}