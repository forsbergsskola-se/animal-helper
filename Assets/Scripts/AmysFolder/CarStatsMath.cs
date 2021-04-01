using UnityEngine;

public class CarStatsMath : MonoBehaviour
{
    public int PushSpeed; // Front
    public int BoostForce; // Body
    public float Drag; // Spoiler
    public float WobbleAmount; // Front Wheel & Back Wheel

    public void Awake()
    {
        StatController();
    }

    public void StatController() {
        var body = HackySave.Body;
        var front = HackySave.Front;
        var wheel = HackySave.Wheel;
        var spoiler = HackySave.Spoiler;
        PushSpeed = 10 * (front.item.rarityLevel + 200) + (front.level * 150); 
        BoostForce = 10 * ((body.item.rarityLevel * 100) + (body.level * 100) * 10); 
        WobbleAmount = 10 - ((wheel.item.rarityLevel + 1.0f) + (wheel.level * 0.5f));
        Drag = 0.8f - ((0.1f * spoiler.item.rarityLevel) + (0.1f * spoiler.level));
        Drag = 0.5f;
    }
}
