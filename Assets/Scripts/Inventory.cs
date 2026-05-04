using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory {
    public event EventHandler OnItemListChanged;

    private List<Item> ItemList;

    private int InventorySlotCount;
    private ItemSlot[] InventorySlotArray;

    public Inventory() {
        ItemList = new List<Item>();

        InventorySlotCount = 9;
        InventorySlotArray = new ItemSlot[InventorySlotCount];
        for (int i = 0; i < InventorySlotCount; i++) {
            InventorySlotArray[i] = new ItemSlot(i);
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
                ItemSlot emptySlot = GetNextEmptyItemSlot();
                if (emptySlot == null) return false;
                emptySlot?.SetItem(item);
            }
        }
        else {
            ItemList.Add(item);
            ItemSlot emptySlot = GetNextEmptyItemSlot();
            if (emptySlot == null) return false;
            emptySlot?.SetItem(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
        return true;
    }

    public List<Item> GetItemList() {
        return ItemList;
    }


    /*========== Inventory Slots ==========*/
    public ItemSlot GetNextEmptyItemSlot() {
        foreach (ItemSlot inventorySlot in InventorySlotArray) {
            if (inventorySlot.IsEmpty()) {
                return inventorySlot;
            }
        }

        return null;
    }

    public ItemSlot[] GetItemSlotArray() {
        return InventorySlotArray;
    }
}
