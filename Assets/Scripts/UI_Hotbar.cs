using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Hotbar : MonoBehaviour {
    private readonly float _itemSlotCellSize = 30f;

    private Inventory inventory;
    private Hotbar hotbar;

    private Transform HotbarMenu;
    private Transform ItemSlotTemplate;

    private void Awake() {
        HotbarMenu = transform;
        ItemSlotTemplate = HotbarMenu.Find("ItemSlotTemplate");
    }

    public void RefreshHotbar() {
        Debug.Log("Refreshed Hotbar");
        foreach (Transform child in HotbarMenu) {
            if (child == ItemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        foreach (ItemSlot slot in hotbar.GetItemSlotArray()) {
            Item item = slot.GetItem();
            
            RectTransform itemSlotRectTransform = Instantiate(ItemSlotTemplate, HotbarMenu).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * _itemSlotCellSize, y * _itemSlotCellSize);

            if (!slot.IsEmpty()) {
                Image image = itemSlotRectTransform.Find("ItemImage").GetComponent<Image>();
                image.sprite = item.GetSprite();
                TextMeshProUGUI countText = itemSlotRectTransform.Find("Count").GetComponent<TextMeshProUGUI>();
                countText.SetText(item.GetAmount().ToString());
            }
            
            x++;
            if (x > 4) {
                x = 0;
                y++;
            }
        }
    }

    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
        inventory.OnItemListChanged += OnItemListChangedEvent;
        RefreshHotbar();
    }
    
    public void SetHotbar(Hotbar hotbar) {
        this.hotbar = hotbar;
    }

    private void OnItemListChangedEvent(object sender, System.EventArgs e) {
        RefreshHotbar();
    }
}