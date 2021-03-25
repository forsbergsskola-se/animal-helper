using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRotation : MonoBehaviour
{
    public float RotSpeed = 30f;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, RotSpeed * Time.deltaTime);
    }
}
