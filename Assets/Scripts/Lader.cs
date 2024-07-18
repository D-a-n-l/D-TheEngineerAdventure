﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lader : MonoBehaviour
{
    private float inputVertical;
    public float speed;
    Rigidbody2D rb;
    private Animator anim;
    public bool isGrounded = false;
    public float distance;
    public LayerMask whatisLadder;
    private bool Climbing;

    //переменная для установки макс. скорости персонажа
    public float maxSpeed = 20f; 
    //переменная для определения направления персонажа вправо/влево
    private bool isFacingRight = true;
    //ссылка на компонент анимаций

	//находится ли персонаж на земле или в прыжке?

	//ссылка на компонент Transform объекта
	//для определения соприкосновения с землей
	public Transform groundCheck;
	//радиус определения соприкосновения с землей
	private float groundRadius = 0.2f;
	//ссылка на слой, представляющий землю
	public LayerMask whatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate() {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatisLadder);

        if(hitinfo.collider != null) {
            if(Input.GetKey(KeyCode.W)) {
                Climbing = true;
            }
        } else {
            Climbing = false;
        }

        if(Climbing == true && hitinfo.collider != null) {
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.position.x, inputVertical * speed);
            rb.gravityScale = 0;
            anim.SetBool ("Climb", true);
            anim.SetBool ("Ground", true);
        } else {
            rb.gravityScale = 1;
            anim.SetBool ("Climb", false);
            anim.SetBool ("Ground", false);
        }
    }

}
