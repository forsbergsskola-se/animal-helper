using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Gatcha
{
    [System.Serializable]
    public class GatchaCalculator : MonoBehaviour
    {
        public Button GachaButton;
        public int total;
        public int randomNumber;
        public int rewardAmount = 3;
        public int[] GatchaTableDropRate = { 40, 30, 20, 8, 2 };
        public List<GatchaScriptableObjects> gachaList;

        //Rarity: White: Common, Green: Uncommon, Blue: Rare, Purple: Epic, Gold: Legendary
        //White: 30, Green: 40, Blue: 20, Purple: 8, Gold: 2

        //Ask for SO to get the item and set possition binded to parent object
        //Make a libary with all of the pices that is in need for the building. (Question is Preformence?)
        //Sepret the Gatcha and the Garach should work fine with helping the preformence. Unsure about the objects tho and the grafical limits.
        //Make the Choosing of the texture for each piece.
        //Item need model, texture, possition, binding to set parent, rotation, mid point, mass
        //Make SOs for each car piece?

        //Make Arrays for all the Pieces in Display. Text rarity, Image sprite, Text amount ++, color for the sprite.
        //Each rarity should be able to hold there own thing.
        //public string[] rarities; //Call for its name + Color

        //List of the Desplay of the Items
        public Text[] nameText;
        public Text[] rarityText;
        public Image[] artworkImage;
        public Text[] amount;
        public void GachaRoll()
        {
            /*
            // Version 1:
            public int[] amounts;
            public int[] chances;
            public string[] titles;
            public string[] descriptions;

            // Version 2
            [Serializable]
            public class GachaItem{
              public int amount;
              public int chance;
              public string title;
              public string descriptions;
            }

            public GachaItem[] items;
            In version 1:
            amounts: 7
            chances: 1
            titles: 100
            descriptions: 0
            items: 5 or 7 or anything else
            Code now:
            int[] weights = {40, 30, 20, 10, 0}
            var roll = int.Random(0, weights[0])
            for(i = 0; i < weights.Length; i++){
               if(weights[i] >= roll)
                  // it is item i
            }
            Code with weight system:
            int[] weights = {10, 10, 10, 10, 10};
            var totalWeights = weights.Sum(); // use linq, it adds all values together. Result: 50
            var random = int.Random(0, totalWeights); // between 0 and 50, this maybe is 31

            var total = weights[0]; // starts at 10
            var i = 0; // index starts at 0
            while(total < random){
               i++; // 1 || 2 || 3
               total += weights[i]; // 20 || 30 || 40
            }

            Why do systems prefer weights over chances?
            If there's 100 items
            And legendaries have 0.1% chance and rares 5% and epics 10% or so
            Then it's really difficult for designers to make it have a sum of 100%
            It's easier to say:
            legendary weight = 1
            rareWeight = 50
            epic Weight = 100
            */

            for (int d = 0; d < rewardAmount; d++)
            {
                Debug.Log("Current Roll " + d);
                /*
                */
                foreach(var item in GatchaTableDropRate)
                {
                    total += item;
                }
                randomNumber = Random.Range(0, total); //Total should be the total amount inside the drop table.
                //randomNumber = Random.Range(0, 100);
                for (int i = 0; i < GatchaTableDropRate.Length; i++)
                {
                    if (randomNumber <= GatchaTableDropRate[i])
                    {
                        nameText[d].text = gachaList[i].name;
                        rarityText[d].text = gachaList[i].gatchaItemRarity;
                        artworkImage[d].sprite = gachaList[i].gatchaItemSprite;
                        gachaList[d].gatchaItemAmount++;
                        amount[d].text = gachaList[i].gatchaItemAmount.ToString();
                        artworkImage[d].color = gachaList[i].rarityColor;
                        return;
                    }
                    else
                    {
                        randomNumber -= GatchaTableDropRate[i];
                    }
                }
            }
            
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
