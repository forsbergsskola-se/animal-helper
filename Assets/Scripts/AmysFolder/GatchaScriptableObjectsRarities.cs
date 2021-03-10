using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Gatcha
{
    [CreateAssetMenu(fileName = "New Gatcha Rarity", menuName = "Gatcha Rarity")]
    public class GatchaScriptableObjectsRarities : ScriptableObject
    {
        public Color rarityColor;
        public string gatchaItemRarity; // Might make it into color codes for RBG to indicate Raritys. Will see what might work best.
    }
}
