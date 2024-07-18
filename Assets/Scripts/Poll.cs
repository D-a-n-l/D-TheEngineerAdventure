using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poll : MonoBehaviour
{
    Rigidbody2D  rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Invoke("DropPlatform", 1);
            Destroy(gameObject, 4);
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
    }

}
