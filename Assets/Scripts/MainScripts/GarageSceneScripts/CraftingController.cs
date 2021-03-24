using UnityEngine;

public class CraftingController : MonoBehaviour {
    public InventoryObject inventory;
    public int amountForFusion = 5;

    public void Fuse() {
        if (inventory.FusionCount() >= amountForFusion && inventory.CanFuse()) {
            inventory.Fusion(amountForFusion);
            Debug.Log("Fused!");
        }
    }
    public void Grind() {
        if (inventory.FusionCount() > 0) {
            Debug.Log("Grinded? Ground?");
        }
    }
}