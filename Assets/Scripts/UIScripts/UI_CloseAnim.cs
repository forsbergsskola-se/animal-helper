using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CloseAnim : MonoBehaviour
{
    public bool closeUpward;
    
    private bool anticipation = true;
    float offsetY = -10f;
    public int FramesDelay;
    private RectTransform rect;

    private Vector2 VectorOffset = new Vector2(0,0.1f);
    // Start is called before the first frame update
    void Start()
    {
        rect = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
           
        FramesDelay--;
        if (FramesDelay <= 0)
        {
            PanAway();
        }
        if (FramesDelay <= -200) this.enabled = false;
    }
    
    void PanAway()
    {

       

        rect.offsetMax += VectorOffset;
        rect.offsetMin += VectorOffset;
        
        if (anticipation)
        {
            offsetY *= 0.98f;
            if (offsetY <= -0.01f) anticipation = false;
        }
        else
        {
            offsetY = Mathf.Abs(offsetY);
            offsetY *= 1.3f;
        }

        if (closeUpward)
        {
            VectorOffset.y = +offsetY;
 
        }
        else
        {
            VectorOffset.y = -offsetY;
        }
        
        if (offsetY > 500) this.enabled = false;
       

    }

}


