﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Jumpp : MonoBehaviour
{   
        private float inputVertical;
    public float speed;


    public float distance;
    public LayerMask whatisLadder;
    private bool Climbing;

    public static Rigidbody2D rb;
    //переменная для установки макс. скорости персонажа
    public float maxSpeed = 20f; 
    //переменная для определения направления персонажа вправо/влево
    private bool isFacingRight = true;
    //ссылка на компонент анимаций
    private Animator anim;
	//находится ли персонаж на земле или в прыжке?
	public bool isGrounded = false;
	//ссылка на компонент Transform объекта
	//для определения соприкосновения с землей
	public Transform groundCheck;
	//радиус определения соприкосновения с землей
	private float groundRadius = 0.2f;
	//ссылка на слой, представляющий землю
	public LayerMask whatIsGround;

    /// <summary>
    /// Начальная инициализация
    /// </summary>
	private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
    /// <summary>
    /// Выполняем действия в методе FixedUpdate, т. к. в компоненте Animator персонажа
    /// выставлено значение Animate Physics = true и анимация синхронизируется с расчетами физики
    /// </summary>
	private void FixedUpdate()
    {
		//определяем, на земле ли персонаж
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); 
		//устанавливаем соответствующую переменную в аниматоре
		anim.SetBool ("Ground", isGrounded);
		//устанавливаем в аниматоре значение скорости взлета/падения
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
        //если персонаж в прыжке - выход из метода, чтобы не выполнялись действия, связанные с бегом
        if (!isGrounded)
            return;
        //используем Input.GetAxis для оси Х. метод возвращает значение оси в пределах от -1 до 1.
        //при стандартных настройках проекта 
        //-1 возвращается при нажатии на клавиатуре стрелки влево (или клавиши А),
        //1 возвращается при нажатии на клавиатуре стрелки вправо (или клавиши D)
        float move = Input.GetAxis("Horizontal");

        //в компоненте анимаций изменяем значение параметра Speed на значение оси Х.
        //приэтом нам нужен модуль значения
        anim.SetFloat("Speed", Mathf.Abs(move));

        //обращаемся к компоненту персонажа RigidBody2D. задаем ему скорость по оси Х, 
        //равную значению оси Х умноженное на значение макс. скорости
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //если нажали клавишу для перемещения вправо, а персонаж направлен влево
        if(move > 0 && !isFacingRight)
            //отражаем персонажа вправо
            Flip();
        //обратная ситуация. отражаем персонажа влево
        else if (move < 0 && isFacingRight)
            Flip();

            
    }

	private void Update()
	{
		//если персонаж на земле и нажат пробел...
		if (isGrounded && Input.GetKeyDown(KeyCode.Space)) 
		{
			//устанавливаем в аниматоре переменную в false
			anim.SetBool("Ground", false);
			//прикладываем силу вверх, чтобы персонаж подпрыгнул
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 900));				
		}


        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatisLadder);
    
        if(hitinfo.collider != null && Input.GetKey(KeyCode.W)){ 
                Climbing = true;
                anim.SetBool ("Climb", true);
                            //isGrounded = true;
            
            } else {
                Climbing = false;
                anim.SetBool ("Climb", false);
                            //isGrounded = false;
        }
    
        if(Climbing == true && hitinfo.collider != null) {
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.position.x, inputVertical * speed);
            rb.gravityScale = 0;

        }
         else {
            rb.gravityScale = 1;

        }
	}
    

    /// <summary>
    /// Метод для смены направления движения персонажа и его зеркального отражения
    /// </summary>
    private void Flip()
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= 1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }

}