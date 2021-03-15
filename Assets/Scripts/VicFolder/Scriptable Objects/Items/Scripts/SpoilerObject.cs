using UnityEngine;

[CreateAssetMenu(fileName = "New spoiler", menuName = "Inventory System/Items/Spoiler")]
public class SpoilerObject : ItemObject {
    public float dragReduction;
    public void Awake() {
        type = ItemType.Spoiler;
    }
}