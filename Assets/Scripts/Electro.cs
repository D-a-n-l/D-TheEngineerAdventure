using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electro : MonoBehaviour
{
    public GameObject button;

    void OnTriggerEnter2D()
    {
        button.SetActive(true);
        Time.timeScale = 0.5f;
    }
    void OnTriggerExit2D()
    {   
        button.SetActive(false);
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}