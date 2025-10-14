using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [Header("Configuración")]
    public bool esObjetoBueno = true; 
    public int puntos = 10; 
    public float velocidadCaida = 3f;

    [Header("Límite de destrucción")]
    public float limiteBajo = -6f; 

    void Update()
    {
        
        transform.Translate(Vector3.down * velocidadCaida * Time.deltaTime);

        
        if (transform.position.y < limiteBajo)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Cesta"))
        {
            
            GameManager.instance.AgregarPuntos(puntos);

            
            Destroy(gameObject);
        }
    }
}