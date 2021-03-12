using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;


    // Start is called before the first frame update
    private void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    private void Update()
    {
        var targetPosition = player.position + offset;
        //targetPosition.x = 0;
        transform.position = targetPosition;
    }
}
