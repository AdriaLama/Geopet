using UnityEngine;

public class movPJ : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rb2D.linearVelocity = new Vector2(horizontal * speed, rb2D.linearVelocityY);
    }
}
