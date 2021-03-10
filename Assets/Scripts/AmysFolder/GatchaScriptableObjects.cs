using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gatcha
{
    [CreateAssetMenu(fileName = "New Gatcha Item", menuName = "Gatcha Scriptable Object")]
    public class GatchaScriptableObjects : ScriptableObject
    {
        //public string gatchaItemName;
        public int gatchaItemAmount = 0;
        public string gatchaItemRarity; // Might make it into color codes for RBG to indicate Raritys. Will see what might work best.
        public Sprite gatchaItemSprite;
        // Need to come up with an idea for the Discription of the Animal since it will most likely be a lot of text.
        public string gatchaItemDiscription;
        public void DebugPrint()
        {
            Debug.Log(name + ": " + gatchaItemRarity + ": " + gatchaItemDiscription);
        }
    }
}
