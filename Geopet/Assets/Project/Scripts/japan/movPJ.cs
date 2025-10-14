using UnityEngine;

public class movPJ : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2D;
    private SpriteRenderer sr;
    public Transform cesta;
    public bool posCesta = false;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rb2D.linearVelocity = new Vector2(horizontal * speed, rb2D.linearVelocityY);

        if(horizontal >= 1)
        {
            sr.flipX = true;

            if (posCesta == false)
            {
                Vector2 pos = cesta.position;
                pos.x += 8;
                cesta.position = pos;
                posCesta = true;
            }
           
            
        }
        else if(horizontal <= -1)
        {
            
            sr.flipX = false;
            
            if(posCesta == true)
            {
                Vector2 pos = cesta.position;
                pos.x -= 8;
                cesta.position = pos;
                posCesta = false;
            }
           
        }

        
       
    }
    
}
