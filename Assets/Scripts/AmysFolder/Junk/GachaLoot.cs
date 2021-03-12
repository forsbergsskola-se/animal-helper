using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gacha
{
    [System.Serializable]
    public class GachaLoot : MonoBehaviour
    {
        [SerializeField]
        private Item item;

        [SerializeField]
        private float dropChance;

        public Item PlayerItem
        {
            get
            {
                return item;
            }
        }
        public float PlayerDropChance
        {
            get
            {
                return dropChance;
            }
        }
    }
}

