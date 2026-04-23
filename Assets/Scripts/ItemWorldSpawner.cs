using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public static ItemWorldSpawner Instance { get; private set; }

    [SerializeField] private Transform defaultPfItemWorld;

    private void Awake()
    {
        Instance = this;
    }

    public ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform prefab = item.itemData.pfItemWorld != null
            ? item.itemData.pfItemWorld
            : defaultPfItemWorld;

        Transform transform = Instantiate(prefab, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        return itemWorld;
    }
}
