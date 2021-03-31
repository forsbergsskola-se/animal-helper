using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCamera : MonoBehaviour
{
    public Camera _Cam1;
    public Camera _Cam2;

   
    public void Switchcam(int i)
    {
        deactivateall();
        if (i == 1)
        {
            _Cam1.enabled = true;
        }
        else
        {
            _Cam2.enabled = true;
        }
    }

    public void deactivateall()
    {
        _Cam1.enabled = false;
        _Cam2.enabled = false;
    }
}
