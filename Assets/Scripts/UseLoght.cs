using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseLoght : MonoBehaviour {
    public GameObject button;
    public GameObject button1;
    void OnTriggerEnter2D()
    {
		button.SetActive(true);
		button1.SetActive(false);
    }
    void OnTriggerExit2D()
    {   
        button.SetActive(false);
		button1.SetActive(true);
    }
}
