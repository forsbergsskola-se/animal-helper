using UnityEngine;
using UnityEngine.UI;

public class CraftingController : MonoBehaviour {
    public InventoryObject inventory;
    public PlayerModel player;
    public int amountForFusion = 5;
    public int baseCost = 100;
    public int maxLevel = 3;
    public Text GrindOneText;
    public Text GrindStackText;
    public Text LevelUpText;
    public Text FusionText;

    public AudioSource rewardSound;
    public AudioSource grindSound;
    public AudioSource fuseSound;

    public void Fuse() {
        if (inventory.SelectedCount() >= amountForFusion) {
            int rarity = inventory.SelectedParts[0].item.rarityLevel;
            int fuseCost = 150 * ((rarity + 1) ^ 2);
            if (!player.HasEnoughNutsBolts(fuseCost)) return;
            player.NutsBolts -= fuseCost;
            inventory.Fusion(amountForFusion);
            Debug.Log("Fused!");
            fuseSound.Play();
            FusionText.text = "Fusion: " + fuseCost.ToString();
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
            rewardSound.Play();
            LevelUpText.text = "Level Up: " + totalCost.ToString();

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
            int grindstackCost = 30 * (1 + rarity) * amount;
            
            Debug.Log("Cost to grind: " + grindstackCost);
            if (!player.HasEnoughNutsBolts(grindstackCost)) return;
            player.NutsBolts -= grindstackCost;
            
            inventory.Grinder(amount);
            int scrapEarned = amount * 50 * (1 + rarity);
            player.Scrap += scrapEarned;
            Debug.Log("Grinded " + amount + " parts for " + scrapEarned);
            grindSound.Play();
            GrindStackText.text = "Grind stack: " + grindstackCost.ToString();
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
            grindSound.Play();
            GrindOneText.text = "Grind one: " + grindCost.ToString();
        }
    }
}