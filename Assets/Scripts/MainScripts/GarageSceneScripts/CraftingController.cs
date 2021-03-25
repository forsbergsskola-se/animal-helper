using UnityEngine;

public class CraftingController : MonoBehaviour {
    public InventoryObject inventory;
    public PlayerModel player;
    public int amountForFusion = 5;
    public int resourcePerPart = 100;

    public void Fuse() {
        if (inventory.SelectedCount() >= amountForFusion && inventory.CanFuse()) {
            inventory.Fusion(amountForFusion);
            Debug.Log("Fused!");
        }
    }
    
    public void Grind() {
        if (inventory.SelectedCount() > 0) {
            int partsGrinded = inventory.Grinder();
            Debug.Log(partsGrinded);
            player.Scrap += partsGrinded * resourcePerPart;
        }
    }
}