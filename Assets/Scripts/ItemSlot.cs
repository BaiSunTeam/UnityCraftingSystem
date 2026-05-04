public class ItemSlot {
    private int index;
    private Item item;

    public ItemSlot(int index) {
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