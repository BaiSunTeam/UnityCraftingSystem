using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/ItemSO")]
public class ItemSO : ScriptableObject
{
    // Item Data
    public string itemName;
    public Sprite sprite;
    public bool IsStackable;

    // References
    public Transform pfItemWorld;
}
