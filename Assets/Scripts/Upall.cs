﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upall : MonoBehaviour
{
         public GameObject button;
        void OnTriggerEnter2D()
        {
            button.SetActive(true);

        }
        void OnTriggerExit2D()
        {
            button.SetActive(false);
            Destroy(gameObject);
        }
}