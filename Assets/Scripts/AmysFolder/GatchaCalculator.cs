using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gatcha
{
    public class GatchaCalculator : MonoBehaviour
    {
        public int[] GatchaTableDropRate = { 40, 30, 20, 8, 2 };
        //Rarity: White: Common, Green: Uncommon, Blue: Rare, Purple: Epic, Gold: Legendary
        //White: 30, Green: 40, Blue: 20, Purple: 8, Gold: 2

        //Make Arrays for all the Pieces in Display. Text rarity, Image sprite, Text amount ++, color for the sprite.
        //Each rarity should be able to hold there own thing.
        public string[] rarities; //Call for its name + Color
        //  Or
        public GatchaScriptableObjects[] gatchaRarities = { };
        public GatchaScriptableObjects[] GatchaItems = { };

        private void Start()
        {
            /// <41
            /// <31
            
        }
    }
}

    /*
    void BuyLootBox(string lootBoxId){
     var lootBoxConfig = lootBoxesScriptableObject.GetLootbox(lootBoxId);
        if(!this.player.hasEnoughGold(lootBoxConfig.costs))
            return new Error();
            this.player.Gold -= lootBoxConfig.costs;
       foreach(var item in GenerateRandomLoot(lootBoxConfig))
            this.player.Items.Add(item);
    }

    // ItemInventoryView:
        void OnEnable() => this.itemStashModel.OnItemAdded += CreateItemView;
        void CreateItemView(Item item){
            var itemView = Instantiate(prefab);
            itemView.SetItem(item);
        }

    // ItemView:
       void SetItem(Item item){
            item.OnCountChnanged += UpdateCount;
            this.image.sprite = item.sprite;
            this.rarityImage.color = item.rarity.color;
      }
    */
