using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poll3 : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject, 5);
        }
    }

}
