using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSteeringWheel_Showcase : MonoBehaviour
{
    private float mult = 1;
    private float timerMult;
    private float timer;

    public int FramesDelay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        FramesDelay--;
        if (FramesDelay <= 0)
        {
            this.GetComponent<Slider>().value = (Mathf.Sin(timer) * 0.4f) * mult + 0.5f;

            timer += Time.deltaTime * (5.5f*mult);

            if (timer > 6.08f)
            {
                mult -= 0.05f;
                mult *= 0.93f;
                
            }

            if (mult <= 0.05f)
            {
                mult = 0;
                this.enabled = false;

            }
        }
    }
}
