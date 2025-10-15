using UnityEngine;

public class movPJ : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb2D;
    private SpriteRenderer sr;
    public Transform cesta;
    public float offsetX;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rb2D.linearVelocity = new Vector2(horizontal * speed, rb2D.linearVelocityY);

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
}
