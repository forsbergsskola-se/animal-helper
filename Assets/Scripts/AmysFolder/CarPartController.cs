using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarPartController : MonoBehaviour
{
    public SpriteRenderer Sprite_Body;
    public SpriteRenderer Sprite_Front;
    public SpriteRenderer Sprite_FrontWheel;
    public SpriteRenderer Sprite_BackWheel;
    public SpriteRenderer Sprite_Spoiler;

    public float PushSpeed; // Front
    public int BoostForce; // Body
    public float Drag; // Spoiler
    public float WobbleAmount; // Front Wheel & Back Wheel

    public void Awake()
    {
        //PushSpeed = item.EquipedParts[]
    }
    public void Start()
    {
        
    }
    public void SaveData()
    {
        CarPartSaveSystem.SavePlayer(this);
    }
    public void LoadData()
    {
        CarPartData data = CarPartSaveSystem.LoadCarParts();
        PushSpeed = data.pushSpeed;
        BoostForce = data.boostForce;
        Drag = data.drag;
        WobbleAmount = data.wobbleAmount;
    }
}
