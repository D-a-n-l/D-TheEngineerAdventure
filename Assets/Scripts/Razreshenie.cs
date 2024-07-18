using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Razreshenie : MonoBehaviour
{
    public Dropdown dropdown;

    public void DropDawn()
    {
        if(dropdown.value == 0)
        {
            Screen.SetResolution(640, 480, true);
        }
        if (dropdown.value == 1)
        {
            Screen.SetResolution(720, 480, true);
        }
        if (dropdown.value == 2)
        {
            Screen.SetResolution(800, 600, true);
        }
        if (dropdown.value == 3)
        {
            Screen.SetResolution(1024, 768, true);
        }
        if (dropdown.value == 4)
        {
            Screen.SetResolution(1280, 720, true);
        }
        if (dropdown.value == 5)
        {
            Screen.SetResolution(1280, 800, true);
        }
        if (dropdown.value == 6)
        {
            Screen.SetResolution(1280, 960, true);
        }
        if (dropdown.value == 7)
        {
            Screen.SetResolution(1280, 1024, true);
        }
        if (dropdown.value == 8)
        {
            Screen.SetResolution(1600, 900, true);
        }
        if (dropdown.value == 9)
        {
            Screen.SetResolution(1920, 1080, true);
        }
    }

}
