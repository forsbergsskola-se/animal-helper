using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Gatcha
{
    [CreateAssetMenu(fileName = "New Gatcha Item", menuName = "Gatcha Scriptable Object Item")]
    public class GatchaScriptableObjects : ScriptableObject
    {
        
        public int gatchaItemAmount = 0;
        public Color rarityColor;
        public string gatchaItemRarity; // Might make it into color codes for RBG to indicate Raritys. Will see what might work best.
        public Sprite gatchaItemSprite;
        public void DebugPrint()
        {
            Debug.Log(name + ": " + gatchaItemRarity + ": " + rarityColor);
        }
    }
}
