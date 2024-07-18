using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light1 : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.Universal.Light2D SUN;

    public float constantIntens;
    public float inten;
    private float TimeDown;
 
     void Start()
     {
         SUN = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
                 TimeDown = 1.0f;
     }

    void FixedUpdate()
    {

        if (SUN.intensity != constantIntens) SUN.intensity = constantIntens;

        if (TimeDown > 0) TimeDown -= Time.deltaTime;

        if (TimeDown < 0) TimeDown = 0;

        if (TimeDown == 0)
        {
            inten = Random.Range(0.2f, 1.0f);
            SUN.intensity = inten;
            TimeDown = Random.Range(0.2f, 1.2f);
        }
    }
}