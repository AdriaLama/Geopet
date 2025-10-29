using UnityEngine;

public class movPJ : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb2D;
    private SpriteRenderer sr;
    public Transform cesta;
    public float offsetX;

    
    private float moveDirection = 0f;
    private bool isTouching = false;
    public float deadZoneRadius = 100f; 

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
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
            sr.flipX = true;
            Vector3 pos = cesta.localPosition;
            pos.x = offsetX;
            cesta.localPosition = pos;
        }
        else if (horizontal < 0)
        {
            sr.flipX = false;
            Vector3 pos = cesta.localPosition;
            pos.x = -offsetX;
            cesta.localPosition = pos;
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
}