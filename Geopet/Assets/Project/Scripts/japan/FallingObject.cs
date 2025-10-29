using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [Header("Configuración")]
    public bool esObjetoBueno = true; 
    public int puntos = 10;
    public float velocidadCaida;
    public bool isCoin;

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
            JaponGameManager.instance.AgregarPuntos(puntos);

            if (isCoin)
            {
                gameManager.Instance.AddCoins(5);
                Destroy(gameObject);
            }
            
            Destroy(gameObject);
        }
    }
}