using UnityEngine;

public class Item
{
    public ItemSO itemData;
    public int amount;
    
    public Item(ItemSO itemData, int amount)
    {
        this.itemData = itemData;
        this.amount = amount;
    }

    public Sprite GetSprite()
    {
        return itemData.sprite;
    }

    public override string ToString()
    {
      return amount + " " + itemData.itemName;
    }
}
