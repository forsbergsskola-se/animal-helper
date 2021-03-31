using UnityEngine;

public class CraftingController : MonoBehaviour {
    public InventoryObject inventory;
    public PlayerModel player;
    public int amountForFusion = 5;
    public int baseCost = 100;
    public int maxLevel = 3;
    public void Fuse() {
        if (inventory.SelectedCount() >= amountForFusion) {
            int rarity = inventory.SelectedParts[0].item.rarityLevel;
            int fuseCost = 150 * ((rarity + 1) ^ 2);
            if (!player.HasEnoughNutsBolts(fuseCost)) return;
            player.NutsBolts -= fuseCost;
            inventory.Fusion(amountForFusion);
            Debug.Log("Fused!");
        }
    }
    public void LeveUp()
    {
        if (inventory.SelectedCount() > 0)
        {
            var inventoryObject = inventory.SelectedParts[0];
            var totalCost = baseCost * inventoryObject.item.rarityLevel + 10 * inventoryObject.level;
            //var totalCostV2 = baseCost * inventoryObject.level + 10 * inventoryObject.item.rarityLevel;
            Debug.Log("Level Up Cost " + totalCost);
            if (inventoryObject.level >= maxLevel)
                return;
            if (!player.HasEnoughScrap(totalCost))
                return;
            player.Scrap -= totalCost;
            //player.Scrap -= totalCostV2
            inventory.LevelUp();

        }
    }
    public void Equip()
    {
        if (inventory.SelectedCount() > 0)
        {
            inventory.AddToEquiped();
        }
    }
    public void Unequip()
    {

    }

    public void GrindStack() {
        if (inventory.SelectedCount() > 0) {
            int rarity = inventory.SelectedParts[0].item.rarityLevel;
            int amount = inventory.SelectedParts[0].amount;
            int grindCost = 30 * (1 + rarity) * amount;
            
            Debug.Log("Cost to grind: " + grindCost);
            if (!player.HasEnoughNutsBolts(grindCost)) return;
            player.NutsBolts -= grindCost;
            
            inventory.Grinder(amount);
            int scrapEarned = amount * 50 * (1 + rarity);
            player.Scrap += scrapEarned;
            Debug.Log("Grinded " + amount + " parts for " + scrapEarned);
        }
    }
    
    public void GrindSingle() {
        if (inventory.SelectedCount() > 0) {
            int rarity = inventory.SelectedParts[0].item.rarityLevel;
            int amount = 1;
            int grindCost = 30 * (1 + rarity);

            Debug.Log("Cost to grind: " + grindCost);
            if (!player.HasEnoughNutsBolts(grindCost)) return;
            player.NutsBolts -= grindCost;
            
            inventory.Grinder(amount);
            int scrapEarned = 50 * (1 + rarity);
            player.Scrap += scrapEarned;
            Debug.Log("Grinded " + amount + " part for " + scrapEarned);
        }
    }
}