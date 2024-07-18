using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textures : MonoBehaviour
{
    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }
}
