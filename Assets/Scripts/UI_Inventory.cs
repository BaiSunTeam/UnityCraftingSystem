using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour {
    private PlayerController player;
    private Inventory inventory;
    private Transform InventoryMenu;
    private Transform ItemSlotTemplate;

    private void Awake() {
        InventoryMenu = transform.Find("InventoryMenu");
        ItemSlotTemplate = InventoryMenu.Find("ItemSlotTemplate");
    }

    // TODO: Can be optimized
    public void RefreshInventory() {
        Debug.Log("Refreshed Inventory");
        foreach (Transform child in InventoryMenu) {
            if (child == ItemSlotTemplate) continue;
            Destroy(child.gameObject);
        }


        int x = 0;
        int y = 0;
        float itemSlotCellSize = 30f;
        foreach (Item item in inventory.GetItemList()) {
            RectTransform itemSlotRectTransform = Instantiate(ItemSlotTemplate, InventoryMenu).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("ItemImage").GetComponent<Image>();
            image.sprite = item.GetSprite();
            TextMeshProUGUI countText = itemSlotRectTransform.Find("Count").GetComponent<TextMeshProUGUI>();
            countText.SetText(item.GetAmount().ToString());

            x++;
            if (x > 4) {
                x = 0;
                y++;
            }
        }
    }

    public void SetPlayer(PlayerController player) {
        this.player = player;
    }

    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
        inventory.OnItemListChanged += OnItemListChangedEvent;
        RefreshInventory();
    }

    private void OnItemListChangedEvent(object sender, System.EventArgs e) {
        RefreshInventory();
    }
}