using UnityEngine;

public enum ItemType {
    Spoiler,
    Wheels,
    Body,
    Front
}
public abstract class ItemObject : ScriptableObject {
    public abstract ItemType type { get; }
    public string itemType;
    [TextArea(5,10)]
    public string description;
    public Sprite itemSprite;
    public int rarityLevel;
    public int itemLevel;
    public ItemObject nextRarityObject;
}