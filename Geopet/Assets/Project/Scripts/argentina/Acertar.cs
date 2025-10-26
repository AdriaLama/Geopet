using UnityEngine;

public class Acertar : MonoBehaviour
{
    private LanzarBola lb;
    private Rigidbody2D rb;
    public int score = 0;
    private textoScore ts;
    private movAcertar ma;
    private generarMoneda gm; 

    void Start()
    {
        lb = FindFirstObjectByType<LanzarBola>();
        rb = GetComponent<Rigidbody2D>();
        ts = FindFirstObjectByType<textoScore>();
        ma = FindFirstObjectByType<movAcertar>();
        gm = FindFirstObjectByType<generarMoneda>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Acertar"))
        {
            transform.position = new Vector2(0f, -4.33f);
            lb.isMoving = false;
            lb.isDragging = false;
            transform.localScale = new Vector3(0.4287868f, 0.4287868f, 0.4287868f);

            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;

            ts.score++;
            ma.speed += 0.5f;
            gm.Generar();

            if(gm.isMoneda)
            {
                gameManager.Instance.AddCoins(5);
                gm.isMoneda = false;
            }


        }
        if (collision.gameObject.CompareTag("Porteria"))
        {
            transform.position = new Vector2(0f, -4.33f);
            lb.isMoving = false;
            lb.isDragging = false;
            transform.localScale = new Vector3(0.4287868f, 0.4287868f, 0.4287868f);

            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            gm.Generar();
        }

    }

 
}
