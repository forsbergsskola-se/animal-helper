using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gacha
{
    public class GachaLootTable : MonoBehaviour
    {
        [SerializeField]
        private GachaLoot[] loot;
        private List<Item> droppedGachaItems = new List<Item>();

        public void ShowLoot()
        {
            
        }
    }
}
