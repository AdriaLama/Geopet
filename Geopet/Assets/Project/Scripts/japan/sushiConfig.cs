using System.Collections.Generic;
using UnityEngine;
/*
public class sushiConfig : MonoBehaviour
{
    public List<ConfiguracionSushi> configuracionSushi;
    public int id = 0;
    public void Frutas()
    {
        id = Random.Range(0, 3);
        ConfiguracionSushi configuracion = configuracionSushi[id];

        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null && configuracion.GetComponent<Collider>() != null)
        {
            if (collider is BoxCollider2D boxCollider)
            {
                boxCollider.size = ((BoxCollider2D)configuracion.GetComponent<Collider>()).size;
            }
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0, -configuracion.velocidad);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = configuracion.sprite;
    }
}
*/
