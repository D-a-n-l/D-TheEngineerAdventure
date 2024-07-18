using UnityEngine;

public class move2 : MonoBehaviour {
    [SerializeField] private int speed;
    [SerializeField] private int jump;
    private bool ground;
    private Animator anim;
    private Rigidbody2D rb;
    private Move1 typeController;

    private void Start () {
        anim = GetComponent<Animator> ();
        rb = GetComponent<Rigidbody2D> ();
        typeController = GetComponent<Move1> ();
    }
    private void Update () {
        rb.velocity = new Vector2 (typeController.directionX * speed, rb.velocity.y);
        if (typeController.directionX != 0)
            anim.SetBool ("isRuning", true);
        else if (typeController.directionX == 0)
            anim.SetBool ("isRuning", false);
        Flip ();
        if (typeController.directionY > 0)
            Jump ();
    }
    private void Jump () {
        if (ground == true) {
            rb.AddForce (transform.up * jump, ForceMode2D.Impulse);
            //anim.SetTrigger ("Jump");
        }
    }

    private void Flip () {
        if (typeController.directionX > 0)
            transform.localRotation = Quaternion.Euler (0, 180, 0);
        else if (typeController.directionX < 0)
            transform.localRotation = Quaternion.Euler (0, 0, 0);
    }
    private void OnTriggerStay2D (Collider2D other) {
        if (other.tag == "Ground")
            ground = true;
        if (other.tag == "Ladder") {
            anim.SetBool ("Climb", true);
            rb.gravityScale = 0;
            rb.velocity = new Vector2 (typeController.directionX * speed, typeController.directionY * speed);
        }
    }
    private void OnTriggerExit2D (Collider2D other) {
        if (other.tag == "Ground")
            ground = false;
        if (other.tag == "Ladder") {
            rb.gravityScale = 1;
            anim.SetBool ("Climb", false);
        }
    }
}