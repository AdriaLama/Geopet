using System.Collections;
using UnityEngine;

public class saltoCubo : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float jumpForceSpring;
    private Rigidbody2D rb2D;
    private SpriteRenderer sr;
    private Animator anim;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rb2D.linearVelocity = new Vector2(horizontal * speed, rb2D.linearVelocityY);

        if (horizontal > 0)
        {
            sr.flipX = false;
        }
        else if (horizontal < 0)
        {
            sr.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        SoundManager sm = FindFirstObjectByType<SoundManager>();

        if (collision.gameObject.CompareTag("Plataforma"))
        {       
            ContactPoint2D contact = collision.contacts[0];
          
            if (Vector2.Dot(contact.normal, Vector2.up) > 0.5f)
            {
               
                sm.Canguro();
                rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetBool("Salto", true);
                StartCoroutine(SaltoOff());
            }
        }

        if (collision.gameObject.CompareTag("Muelle"))
        {
            ContactPoint2D contact = collision.contacts[0];

            if (Vector2.Dot(contact.normal, Vector2.up) > 0.5f)
            {
                sm.Colchoneta();
                rb2D.AddForce(Vector2.up * jumpForceSpring, ForceMode2D.Impulse);
                anim.SetBool("Salto", true);
                StartCoroutine(SaltoOff());
            }
        }
    }

    private IEnumerator SaltoOff()
    {
        yield return new WaitForSeconds(1.0f);
        anim.SetBool("Salto", false);
    }

   
}
