using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gatcha
{
    public class GatchaCalculator : MonoBehaviour
    {
        public int[] GatchaTable = { 40, 30, 20, 8, 2 };
        //Rarity: White: Common, Green: Uncommon, Blue: Rare, Purple: Epic, Gold: Ledgendary
        //White: 20, Green: 40, Blut: 30, Purple: 8, Gold: 2

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
