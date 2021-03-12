using UnityEngine;

public enum ItemType {
    Spoiler,
    Wheels,
    Body
}
public abstract class ItemObject : ScriptableObject {
    public GameObject prefab;
    public ItemType type;
    [TextArea(5,10)]
    public string description;
}
