using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_OpenAnim : MonoBehaviour
{

    float offsetY = -10f;
    public int FramesDelay;
    private RectTransform rect;
    public Vector2 VectorStart;
    public Vector2 VectorTargetPos;
    private Vector2 VectorOffset;

    void Start()
    {
        VectorOffset = VectorStart;
        rect = this.GetComponent<RectTransform>();
    }
    
    void FixedUpdate()
    {
        FramesDelay--;
        if (FramesDelay <= 0)
        {
            PanIn();
        }

        if (FramesDelay <= -200) this.enabled = false;
    }
    
    void PanIn()
    {
        rect.offsetMax = VectorOffset;
        rect.offsetMin = VectorOffset;


        VectorOffset = (Vector2.Lerp(VectorOffset, VectorTargetPos, 0.2f));
        VectorOffset.y = (Mathf.Round(VectorOffset.y * 1000)) *0.001f;

    }

}
