using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boevka : MonoBehaviour
{
    public GameObject button;

    void OnTriggerEnter2D()
    {
        button.SetActive(true);
        //Time.timeScale = 0f;
    }
    void OnTriggerExit2D()
    {
        button.SetActive(false);
    }
}
