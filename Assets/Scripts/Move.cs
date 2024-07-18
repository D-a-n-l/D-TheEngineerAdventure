using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{   

    public float maxSpeed = 10f; 

    private bool isFacingRight = true;

    public static Rigidbody2D rb;
    private Animator anim;

    private AudioSource Step;

    private bool stop;

	private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Step = GetComponent<AudioSource>();
    }
	
	private void FixedUpdate()
    {

        float move = Input.GetAxis("Horizontal");


        anim.SetFloat("Speed", Mathf.Abs(move));

        anim.SetFloat("Speed", Mathf.Abs(move));

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //если нажали клавишу для перемещения вправо, а персонаж направлен влево
        if(move > 0 && !isFacingRight)
            //отражаем персонажа вправо
            Flip();
        //обратная ситуация. отражаем персонажа влево
        else if (move < 0 && isFacingRight)
            Flip();

        //если нажали клавишу для перемещения вправо, а персонаж направлен влево
        if (!stop)
        {
            StartCoroutine(PlayStep());
        }
    }


    // Метод для смены направления движения персонажа и его зеркального отражения
    private void Flip()
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }

   IEnumerator PlayStep()
    {
        stop = true;
        Step.Play();
        yield return new WaitForSeconds(0.3f);
        stop = false;
    } 
}
