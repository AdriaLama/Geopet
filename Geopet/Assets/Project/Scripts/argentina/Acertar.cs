using UnityEngine;

public class Acertar : MonoBehaviour
{
    private LanzarBola lb;
    private Rigidbody2D rb;
    public int score = 0;
    private textoScore ts;
    private movAcertar ma;
    void Start()
    {
        lb = FindFirstObjectByType<LanzarBola>();
        rb = GetComponent<Rigidbody2D>();
        ts = FindFirstObjectByType<textoScore>();
        ma = FindFirstObjectByType<movAcertar>();
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Acertar"))
        {
            transform.position = new Vector2(0f, -4.33f);
            lb.isMoving = false;
            lb.isDragging = false;
            transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;

            ts.score++;
            ma.speed += 0.5f;

        }
        if (collision.gameObject.CompareTag("Porteria"))
        {
            transform.position = new Vector2(0f, -4.33f);
            lb.isMoving = false;
            lb.isDragging = false;
            transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

    }

 
}
