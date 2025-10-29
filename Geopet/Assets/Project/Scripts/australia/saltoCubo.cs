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

   
    private float moveDirection = 0f;
    private bool isTouching = false;
    public float deadZoneRadius = 100f; 

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMobileInput();
    }

    void FixedUpdate()
    {
        float horizontal = 0f;

        
        horizontal = Input.GetAxisRaw("Horizontal");

        
        if (isTouching)
        {
            horizontal = moveDirection;
        }

        rb2D.linearVelocity = new Vector2(horizontal * speed, rb2D.linearVelocity.y);

        if (horizontal > 0)
        {
            sr.flipX = false;
        }
        else if (horizontal < 0)
        {
            sr.flipX = true;
        }
    }

    void HandleMobileInput()
    {
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            
            Vector3 playerScreenPos = Camera.main.WorldToScreenPoint(transform.position);
            float touchX = touch.position.x;

            
            float distance = Mathf.Abs(touchX - playerScreenPos.x);

            
            if (distance < deadZoneRadius)
            {
                
                if (isTouching)
                {
                    isTouching = false;
                    moveDirection = 0f;
                }
                return; 
            }

            
            isTouching = true;

            
            if (touchX < playerScreenPos.x)
            {
                moveDirection = -1f;
            }
            
            else
            {
                moveDirection = 1f;
            }

            
            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isTouching = false;
                moveDirection = 0f;
            }
        }
        else
        {
            isTouching = false;
            moveDirection = 0f;
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
