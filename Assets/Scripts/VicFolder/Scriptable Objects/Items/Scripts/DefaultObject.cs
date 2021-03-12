﻿using UnityEngine;

[CreateAssetMenu(fileName = "New default object", menuName = "Inventory System/Items/Default")]
public class DefaultObject : ItemObject {
    public void Awake() {
        type = ItemType.Body;
    }
}
