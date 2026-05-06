public class Hotbar {
    private ItemSlot[] InventorySlotArray;

    public Hotbar() {
        InventorySlotArray = new ItemSlot[2];
        InventorySlotArray[0] = new ItemSlot(0);
        InventorySlotArray[1] = new ItemSlot(1);
    }
    

    public ItemSlot[] GetItemSlotArray() {
        return InventorySlotArray;
    }
}