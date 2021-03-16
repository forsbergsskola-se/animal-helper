using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//github access test
public class CameraFollowScript : MonoBehaviour
{
private Transform player;
    private Vector3 offset;


    private void Start()
    {
        player = GameObject.Find("Car(Clone)").transform;
        offset = transform.position - player.position;
    }

    private void Update()
    {
        var targetPosition = player.position + offset;
        //targetPosition.x = 0;
        transform.position = targetPosition;
    }
}
