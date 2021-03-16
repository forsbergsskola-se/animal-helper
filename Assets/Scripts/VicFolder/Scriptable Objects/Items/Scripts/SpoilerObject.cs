using UnityEngine;

[CreateAssetMenu(fileName = "New spoiler", menuName = "Inventory System/Items/Spoiler")]
public class SpoilerObject : ItemObject {
    public float dragReduction;
    public override ItemType type => ItemType.Spoiler;

}