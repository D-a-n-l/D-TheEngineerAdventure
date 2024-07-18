using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsPlayerRRun : MonoBehaviour
{
    private Animator Animator;
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Animator.SetBool("isRuning", true);
        }
        else
        {
            Animator.SetBool("isRuning", false);
        }
    }
}
