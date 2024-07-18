using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float BgSize;
    public float SpeedParallax;

    private Transform camTrans;
    private Transform [] layers;
    private float viewZone = 10;
    private int LeftIndex;
    private int RightIndex;

    private float LastCamX;

    private void Start()
    {
        camTrans = Camera.main.transform;
        LastCamX = camTrans.position.x;

        layers = new Transform[transform.childCount];
        for(int i=0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        LeftIndex = 0;
        RightIndex = layers.Length - 1;
    }

    private void Update()
    {
        float deltaX = camTrans.position.x - LastCamX;
        transform.position += Vector3.right * (deltaX * SpeedParallax);
        LastCamX = camTrans.position.x;


    }


}
