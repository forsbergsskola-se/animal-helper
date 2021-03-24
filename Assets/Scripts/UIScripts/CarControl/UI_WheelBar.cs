using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_WheelBar : MonoBehaviour
{
    
    private Quaternion rotation;
    private Vector3 rotVector;

    public SliderTarget sliderTarget;
    public SliderSteeringWheel sliderSteeringWheel;

    public UI_wheel leftWheel;
    public UI_wheel rightWheel;
    
    public float wobbleAmountMultiplier = 1;
    [HideInInspector]
    public float wobbleAmount;
    [HideInInspector]
    public float wobbleSpeedTimer;
    
    

    void FixedUpdate()
    {
        
        wobbleAmount = sliderTarget.targetPos - sliderSteeringWheel.targetPos;
        leftWheel.WobbleAmount =  Mathf.Clamp(wobbleAmount, 0, 1);
        rightWheel.WobbleAmount =  Mathf.Abs(Mathf.Clamp(wobbleAmount, -1, 0));
        wobbleAmount = Mathf.Abs(wobbleAmount) * wobbleAmountMultiplier;
        
        rotVector.z = Mathf.Sin(wobbleSpeedTimer) * Mathf.Clamp(wobbleAmount,0,2);
        rotation.eulerAngles = rotVector;
        this.transform.rotation = rotation;


        wobbleAmount *= 0.96f;

    }
    
    
}
