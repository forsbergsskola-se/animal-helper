using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_WheelWobble : MonoBehaviour
{
    private UI_WheelBar wheelBar;
    
    private WheelJoint2D[] wheelJoints;

    private Vector2 WheelWobble;
    

    void Start()
    {
        wheelBar = FindObjectOfType<UI_WheelBar>();
        
        wheelJoints = GetComponents<WheelJoint2D>();
    }


    void FixedUpdate()
    {
        
        WheelWobble.x = Mathf.Clamp(wheelBar.wobbleAmount*0.1f,0,0.5f);
        wheelJoints[0].connectedAnchor = WheelWobble;
        wheelJoints[1].connectedAnchor = WheelWobble;
    }
}
