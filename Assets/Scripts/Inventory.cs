using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory {
    public event EventHandler OnItemListChanged;

    private List<Item> ItemList;

    private int InventorySlotCount;
    private InventorySlot[] InventorySlotArray;

    public Inventory() {
        ItemList = new List<Item>();

        InventorySlotCount = 9;
        InventorySlotArray = new InventorySlot[InventorySlotCount];
        for (int i = 0; i < InventorySlotCount; i++) {
            InventorySlotArray[i] = new InventorySlot(i);
        }
    }

    // TODO: Can be optimized
    public bool AddItem(Item item) {
        Debug.Log(item.ToString());
        if (item.IsStackable()) {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in ItemList) {
                if (inventoryItem.GetItemName() == item.GetItemName()) {
                    inventoryItem.IncreaseAmount(1);
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory) {
                ItemList.Add(item);
                InventorySlot emptySlot = GetNextEmptyInventorySlot();
                emptySlot?.SetItem(item);
                if (emptySlot == null) return false;
            }
        }
        else {
            ItemList.Add(item);
            InventorySlot emptySlot = GetNextEmptyInventorySlot();
            emptySlot?.SetItem(item);
            if (emptySlot == null) return false;
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
        return true;
    }

    public List<Item> GetItemList() {
        return ItemList;
    }


    /*========== Inventory Slots ==========*/
    public InventorySlot GetNextEmptyInventorySlot() {
        foreach (InventorySlot inventorySlot in InventorySlotArray) {
            if (inventorySlot.IsEmpty()) {
                return inventorySlot;
            }
        }

        return null;
    }

    public InventorySlot[] GetInventorySlotArray() {
        return InventorySlotArray;
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
