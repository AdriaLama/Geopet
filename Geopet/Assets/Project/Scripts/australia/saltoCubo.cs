using UnityEngine;

public class saltoCubo : MonoBehaviour
{
    public int speed;
    public float horizontal;
    private Rigidbody2D rb2D;
    public int jumpForce;
    private bool isGrounded;
    private bool wasGrounded;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal >= 0)
        {
            rb2D.linearVelocity = new Vector2(horizontal * speed, rb2D.linearVelocityY);
            float velocidadHorizontal = Mathf.Abs(rb2D.linearVelocityX);
        }
        if (horizontal <= 0)
        {
            rb2D.linearVelocity = new Vector2(horizontal * speed, rb2D.linearVelocityY);
            float velocidadHorizontal = Mathf.Abs(rb2D.linearVelocityX);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            rb2D.AddForce(Vector2.up * jumpForce ,ForceMode2D.Impulse);
            
        }
    }
}
