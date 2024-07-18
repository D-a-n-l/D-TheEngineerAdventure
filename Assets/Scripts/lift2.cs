using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lift2 : MonoBehaviour
{
    Rigidbody2D rb;
    public float distance;
    public LayerMask whatisLadder;

    void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatisLadder);

        if(hitinfo.collider != null) {
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {   
                transform.position = new Vector2(-37.68f, 9.53f);
            }

        }
    }
}
