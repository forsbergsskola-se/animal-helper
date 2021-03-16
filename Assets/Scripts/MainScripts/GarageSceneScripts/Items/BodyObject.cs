using UnityEngine;

[CreateAssetMenu(fileName = "New car body", menuName = "Inventory System/Items/Body")]
public class BodyObject : ItemObject {
    public int forceBonus;
    public override ItemType type => ItemType.Body;

}