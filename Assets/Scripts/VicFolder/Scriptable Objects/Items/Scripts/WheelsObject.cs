using UnityEngine;

[CreateAssetMenu(fileName = "New wheels", menuName = "Inventory System/Items/Wheels")]
public class WheelsObject : ItemObject {
    public float speedBonus;
    public float frictionReduction;
    public override ItemType type => ItemType.Wheels;
}