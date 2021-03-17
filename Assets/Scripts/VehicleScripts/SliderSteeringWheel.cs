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
    
    private GameObject car;
    private Wheel wheel;


    private float randompos;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInParent<Slider>();
        StartCoroutine(Initiate());
    }


    void Update()
    {

        rotVector.z = - slider.value * 720;
        rotation.eulerAngles = rotVector;
        this.transform.rotation = rotation;
        
    }








    IEnumerator Initiate()
    {
        yield return new WaitForSeconds(0.1f);
        car = GameObject.Find("Car(Clone)");

        wheel = car.GetComponentInChildren<Wheel>();
    }
    
}
