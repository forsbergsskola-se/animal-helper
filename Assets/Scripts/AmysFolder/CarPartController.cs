using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarPartController : MonoBehaviour
{
    public SpriteRenderer[] sprites;
    public InventoryObject item;
    public UI_WheelBar wheelBar;
    public MoveCar moveCar;
    public DragButton dragButton;

    public float PushSpeed; // Front
    public int BoostForce; // Body
    public float Drag; // Spoiler
    public float WobbleAmount; // Front Wheel & Back Wheel
    public GameObject rigidBody;
    
    public void PartData()
    {

        PushSpeed = moveCar.pushSpeed;
        BoostForce = moveCar.boostForce;
        Drag = dragButton.DuckDrag;
        WobbleAmount = wheelBar.wobbleAmount;

    }
    public void SaveData()
    {
        CarPartSaveSystem.SavePlayer(this);
    }
    public void LoadData()
    {
        /// No non of the math is done its just changing of the edits of the scripts stat value. It was about the stats but can't remember
        CarPartData data = CarPartSaveSystem.LoadCarParts();
        PushSpeed = data.pushSpeed;
        BoostForce = data.boostForce;
        Drag = data.drag;
        WobbleAmount = data.wobbleAmount;
        //Mass = data.mass;
        for (var i = 0; i < sprites.Length; i++)
        {
            sprites[0].sprite = data.Body.EquipedParts[0].item.itemSprite;
            sprites[1].sprite = data.Front.EquipedParts[1].item.itemSprite;
            sprites[2].sprite = data.FrontWheel.EquipedParts[2].item.itemSprite;
            sprites[3].sprite = data.BackWheel.EquipedParts[3].item.itemSprite;
            sprites[4].sprite = data.Spoiler.EquipedParts[4].item.itemSprite;
        }
    }
}
