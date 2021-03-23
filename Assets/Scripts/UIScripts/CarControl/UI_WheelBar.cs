using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_WheelBar : MonoBehaviour
{
    
    private Quaternion rotation;
    private Vector3 rotVector;


    
    public float wobbleAmount;
    public float wobbleSpeedTimer;

    void FixedUpdate()
    {
        
        rotVector.z = Mathf.Sin(wobbleSpeedTimer) * Mathf.Clamp(wobbleAmount,0,2);
        rotation.eulerAngles = rotVector;
        this.transform.rotation = rotation;


        wobbleAmount *= 0.96f;

    }
    
    
}
