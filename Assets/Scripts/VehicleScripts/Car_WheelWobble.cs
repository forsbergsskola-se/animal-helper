using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_WheelWobble : MonoBehaviour
{
    private UI_WheelBar wheelBar;
    
    private WheelJoint2D[] wheelJoints;

    private Vector2 frontWheel;
    

    void Start()
    {
        wheelBar = FindObjectOfType<UI_WheelBar>();
        
        wheelJoints = GetComponents<WheelJoint2D>();
    }


    void FixedUpdate()
    {
        frontWheel.x = Mathf.Clamp(wheelBar.wobbleAmount*0.05f,0,0.3f);
        Debug.Log(frontWheel.x);
        wheelJoints[0].connectedAnchor = frontWheel;
        wheelJoints[1].connectedAnchor = frontWheel;
    }
}
