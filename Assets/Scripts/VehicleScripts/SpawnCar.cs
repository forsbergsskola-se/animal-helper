using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject Car;
    private GameObject frontWheel;
    private GameObject backWheel;
    private Vector2 connectedAnchor;

    private WheelJoint2D[] wheelJoints;

    void Start()
    {
        var Car = Instantiate(this.Car, Vector3.zero , Quaternion.identity);
        frontWheel = Car.transform.GetChild(0).gameObject;
        backWheel = Car.transform.GetChild(1).gameObject;

        wheelJoints = Car.GetComponents<WheelJoint2D>();
        
        wheelJoints[0].connectedAnchor = new Vector2(0.04f,0.12f);
        wheelJoints[1].connectedAnchor = new Vector2(0.08f,-0.05f);

        Camera.main.GetComponent<CameraFollowScript>().enabled = true;
    }


}
