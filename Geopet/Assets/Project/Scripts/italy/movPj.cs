using UnityEngine;

public class movPj : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    public bool isFloor;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        jumpPJ();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }

    private void jumpPJ()
    {
        if (Input.GetKey(KeyCode.Space) && isFloor)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isFloor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isFloor = true;
        }
      
    }
}
