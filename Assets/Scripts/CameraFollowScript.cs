using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
public Transform player;
    private Vector3 offset;


    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void Update()
    {
        var targetPosition = player.position + offset;
        //targetPosition.x = 0;
        transform.position = targetPosition;
    }
}
