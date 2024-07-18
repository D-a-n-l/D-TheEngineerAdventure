using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Trig : MonoBehaviour
{
    public GameObject CanvasObject;

    private void OnTriggerEnter2D(Collider2D col)
    {
            CanvasObject.SetActive(true);

    }
}