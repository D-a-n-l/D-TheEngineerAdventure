using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Textt : MonoBehaviour
{
    Text text;
    public static int key;
    void Start()
    {
        text = GetComponent<Text>();
        key = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = key.ToString() + "/3";

        if(Input.GetKeyDown(KeyCode.F) && key == 3)
        {
            SceneManager.LoadScene("Factori");
        }
    }
}
