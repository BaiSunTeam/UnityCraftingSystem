using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework.Internal;
using UnityEngine.AdaptivePerformance;

public class Inventory {
    public event EventHandler OnItemListChanged;

    private List<Item> ItemList;

    private int InventorySlotCount;
    private InventorySlot[] InventorySlotArray;

    public Inventory() {
        ItemList = new List<Item>();

        InventorySlotCount = 10;
        InventorySlotArray = new InventorySlot[InventorySlotCount];
        for (int i = 0; i < InventorySlotCount; i++) {
            InventorySlotArray[i] = new InventorySlot(i);
        }
    }


    // TODO: Can be optimized
    public void AddItem(Item item) {
        Debug.Print(item.ToString());
        if (item.IsStackable()) {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in ItemList) {
                if (inventoryItem.GetItemName() == item.GetItemName()) {
                    inventoryItem.IncreaseAmount(1);
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory) ItemList.Add(item);
        }
        else {
            ItemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList() {
        return ItemList;
    }

    public class InventorySlot {

        private int index;
        private Item item;

        public InventorySlot(int index) {
            this.index = index;
        }

        public Item GetItem() {
            return item;
        }

        public void SetItem(Item item) {
            this.item = item;
        }

        public void RemoveItem() {
            item = null;
        }

        public bool IsEmpty() {
            return item == null;
        }
    }
}
