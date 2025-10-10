using UnityEngine;

public class saltoCubo : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rb2D.linearVelocity = new Vector2(horizontal * speed, rb2D.linearVelocityY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {       
            ContactPoint2D contact = collision.contacts[0];
          
            if (Vector2.Dot(contact.normal, Vector2.up) > 0.5f)
            {
                rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
