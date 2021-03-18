using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SliderSteeringWheel : MonoBehaviour
{
    private Slider slider;
    private Quaternion rotation;
    private Vector3 rotVector;
    

    
    public float targetPos;

    private float randompos;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInParent<Slider>();

    }


    void FixedUpdate()
    {

   
    }

    public void GetRotationAndPosUpdate()
    {
        rotVector.z = - slider.value * 720;
        rotation.eulerAngles = rotVector;
        this.transform.rotation = rotation;

        targetPos = slider.value;
    }







    
}
