using UnityEngine;

public class CraftingSystem_Testing : MonoBehaviour {

    [SerializeField] private PlayerController player;
    [SerializeField] private UI_Inventory uiInventory;

    [SerializeField] private StartingItem[] startingItemArray;

    [System.Serializable]
    public struct StartingItem {
        public ItemSO itemSO;
        public int amount;
        public Vector2Int position;
    }

    private void Start() {
        uiInventory.SetPlayer(player);
        uiInventory.SetInventory(player.GetInventory());

        Inventory playerInventory = player.GetInventory();
        foreach (StartingItem startingItem in startingItemArray) {
            playerInventory.AddItem(
                new Item(startingItem.itemSO, startingItem.amount)
            );
        }
    }

}
