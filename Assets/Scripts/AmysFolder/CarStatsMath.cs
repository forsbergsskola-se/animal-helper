using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStatsMath : MonoBehaviour
{
    public float PushSpeed; // Front
    public int BoostForce; // Body
    public float Drag; // Spoiler
    public float WobbleAmount; // Front Wheel & Back Wheel

    public void Start()
    {
        StatController();
    }

    public void StatController()
    {
        var body = HackySave.Body;
        var front = HackySave.Front;
        var wheel = HackySave.Wheel;
        var spoiler = HackySave.Spoiler;
        //Debug.Log("Front Rarity level " + front.item.rarityLevel);
        PushSpeed = 1000.0f * (front.item.rarityLevel + 1.0f) + (front.level * 0.5f); // 
        BoostForce = 500 * (body.item.rarityLevel + 1) + (body.level * 1); // 
        WobbleAmount = 2 - (((wheel.item.rarityLevel + 1.0f) + (wheel.level)) * 0.5f);
        Drag = 16 - ((spoiler.item.rarityLevel + 1.0f) + (spoiler.level * 0.5f));

    /*
    if (front.item != null)
    {
        this.PushSpeed = 5.0f * (front.item.rarityLevel + 1.0f) + (front.level * 0.5f);
    }
    else { 
        PushSpeed = 5.0f * (1.0f) + (0.5f);
    }
    if (body.item != null)
    {
        this.BoostForce = 500 * (body.item.rarityLevel + 1) + (body.level * 1);
    }
    if (wheel.item != null)
    {
        this.WobbleAmount = 2 - (((wheel.item.rarityLevel + 1.0f) + (wheel.level)) * 0.5f);
    }
    if (spoiler.item != null)
    {
        this.Drag = 16 - ((spoiler.item.rarityLevel + 1.0f) + (spoiler.level * 0.5f));
    }
    */
}
}
