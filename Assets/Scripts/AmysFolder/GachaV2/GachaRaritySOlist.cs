using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaRaritySOlist : ScriptableObject
{
    public int rarityLevel = 0; //Add 1 for each level.
    public List<ItemObject> itemList;
    public List<GachaSOItems> GachaitemList;
}
