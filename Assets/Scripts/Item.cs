using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Item
{
    private ItemSO itemData;
    private int amount;
    
    public Item(ItemSO itemData, int amount)
    {
        this.itemData = itemData;
        this.amount = amount;
    }

    public Sprite GetSprite()
    {
        return itemData.sprite;
    }

    public string GetItemName()
    {
        return itemData.itemName;
    }

    public int GetAmount()
    {
        return amount;
    }

    public Transform GetPrefab()
    {
        return itemData.pfItemWorld;
    }

    public bool IsStackable()
    {
        return itemData.IsStackable;
    }

    public void IncreaseAmount(int amt)
    {
        amount += amt;
    }

    public override string ToString()
    {
      return amount + " " + itemData.itemName;
    }
}
