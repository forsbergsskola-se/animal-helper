using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStatsMath : MonoBehaviour
{
    public int PushSpeed; // Front
    public int BoostForce; // Body
    public float Drag; // Spoiler
    public float WobbleAmount; // Front Wheel & Back Wheel

    public void Start()
    {
    }
    public void Awake()
    {
        StatController();

    }

    public void StatController()
    {
        var body = HackySave.Body;
        var front = HackySave.Front;
        var wheel = HackySave.Wheel;
        var spoiler = HackySave.Spoiler;
        PushSpeed = 10 * (front.item.rarityLevel + 200) + (front.level * 150); 
        BoostForce = 10 * ((body.item.rarityLevel * 100) + (body.level * 100) * 10); 
        WobbleAmount = 10 - ((wheel.item.rarityLevel + 1.0f) + (wheel.level * 0.5f));
        // Drag = 0.8 - ((0.1 * rarity) + (0.1 * item level));
        Drag = 0.5f;
        /// Need to redo, Level effects more then Rarity.
        /// 1 - (0.8 * ((4 * 1 ) * ((0.1 + 3) *0.1))) = 0.008 Legendary on Max level.
        /// 1 - (0.8 * ((1 * 1 ) * ((0.1 + 1) *0.1))) = 0.912 Common on level 0.

        /*
        if (front.item != null)
        {
        }
        */
    }
}
