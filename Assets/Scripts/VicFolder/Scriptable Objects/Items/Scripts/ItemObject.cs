using UnityEngine;

public enum ItemType {
    Spoiler,
    Wheels,
    Body,
    Front
}
public abstract class ItemObject : ScriptableObject {
    public GameObject prefab;
    public abstract ItemType type { get; }
    [TextArea(5,10)]
    public string description;
}