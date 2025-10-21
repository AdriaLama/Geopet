using UnityEngine;

public class LanzarBola : MonoBehaviour
{
    public float speed;
    public float shrinkRate;
    private Rigidbody2D rb;
    private Vector2 startPos;
    public bool isDragging = false;
    public bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void OnMouseDown()
    {
        startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    void OnMouseUp()
    {
        if (!isDragging) return;

        Vector2 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (endPos - startPos).normalized;
        rb.linearVelocity = direction * speed;
        isDragging = false;
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.localScale -= Vector3.one * shrinkRate * Time.deltaTime;

            if (transform.localScale.x < 0.1f)
            {
                transform.localScale = new Vector3(0.1f, 0.1f, 1f);
            }
                
        }
    }

}
