using UnityEngine;

[CreateAssetMenu(fileName = "New car front", menuName = "Inventory System/Items/Front")]
public class FrontObject : ItemObject {
    public float dragReduction;
    public int forceBonus;
    public override ItemType type => ItemType.Front;

}