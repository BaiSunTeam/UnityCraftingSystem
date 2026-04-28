using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> ItemList;

    public Inventory()
    {
        ItemList = new List<Item>();
    }

    // TODO: Can be optimized
    public void AddItem(Item item)
    {   
        Debug.Print(item.ToString());
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in ItemList)
            {
                if (inventoryItem.GetItemName() == item.GetItemName())
                {
                    inventoryItem.IncreaseAmount(1);
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory) ItemList.Add(item);
        }
        else
        {
            ItemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return ItemList;
    }
}
