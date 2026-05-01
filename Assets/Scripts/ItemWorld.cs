using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ItemWorld : MonoBehaviour {
    private Item item;
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItem(Item item) {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }

    public Item GetItem() {
        return item;
    }

    public void DestroySelf() {
        // can be improved
        Destroy(gameObject);
    }
}
