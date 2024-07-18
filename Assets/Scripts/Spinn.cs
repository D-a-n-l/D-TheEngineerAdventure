using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinn : MonoBehaviour
{
    public bool RightSee = true;
    Rigidbody2D rb;
    public float Speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Spin()
    {
        RightSee = !RightSee;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1f, 1f);
    }
    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * moveX * Speed * Time.deltaTime);
        if ((moveX > 0f && !RightSee) || (moveX < 0f && RightSee))
        {
            if (moveX != 0f)
            {
                Spin();
            }
        }
    }
}
